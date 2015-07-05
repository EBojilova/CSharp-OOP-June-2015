namespace _1.Overloading_System.Object_methods
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Grades = new List<double>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<double> Grades { get; set; }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }

        public static bool operator <(Student a, Student b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Student a, Student b)
        {
            return a.CompareTo(b) > 0;
        }

        public override bool Equals(object param)
        {
            // If the cast is invalid, the result will be null
            var student = param as Student;

            // Check if we have valid not null Student object
            if (student == null)
            {
                return false;
            }

            // Compare the reference type member fields
            if (!object.Equals(this.Name, student.Name))
            {
                return false;
            }

            // Compare the value type member fields
            if (this.Age != student.Age)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Student(Name: {0}, Age: {1})", this.Name ?? "<unnamed>", this.Age);
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                throw new ArgumentException("Student is null");
            }

            var ageComparison = this.Age.CompareTo(other.Age);
            if (ageComparison == 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return ageComparison;
        }
    }
}
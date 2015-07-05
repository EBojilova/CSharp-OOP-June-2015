using System;

namespace CustomStackExample
{
    internal class Student : IComparable<Student>
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Student other) //idva ot Interfaca na IComparable
        {
            if (this.Age > other.Age)
            {
                return 1;
            }

            if (this.Age < other.Age)
            {
                return -1;
            }

            return 0;

            // return this.Age.CompareTo(other.Age);
        }
    }
}
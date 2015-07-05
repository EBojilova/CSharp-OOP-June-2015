namespace CustomLinqExtensions
{
    using System;
    using System.Collections.Generic;

    internal class CustomLinqExtensions
    {
        private static void Main()
        {
            var elements = new List<int> { 40, 50, 60, 5, 10, 20, 30 };

            var ordered = elements.SortBy(x => x);

            Console.WriteLine(string.Join(", ", ordered));

            var students = new List<Student>
                               {
                                   new Student("Gosho", 20, 4.5), 
                                   new Student("Pesho", 17, 2), 
                                   new Student("Tanio", 23, 6.00), 
                                   new Student("Ivan", 21, 5.5)
                               };

            var goodStudents = students.Filter(st => st.AverageGrade > 5).SortBy(st => st.Age).Project(st => st.Name);

            var ivan = students.FirstOrDef(st => st.Name == "Ivan");

            // var goodStudents = students.Where(st => st.AverageGrade > 5).OrederBy(st => st.Age).Select(st => st.Name); //tova e LINQ varianta na gornata zaivka
            Console.WriteLine(string.Join("\n", goodStudents));
        }
    }
}
namespace PassingRefParameters
{
    using System;

    public class Student
    {
        public string name;

        public Student(string name)
        {
            this.name = name;
        }

        private static void IncorrectModifyStudent(Student student)
        {
            student = new Student("Changed: " + student.name);

                // tai kato sazdavame nov obekt s new niama da se promeni referentnia tip, koito sme podali
        }

        private static void ModifyStudent(ref Student student)
        {
            // s ref promeniame adresa kam kogoto e sochil student, kam novia student, koito sazdavame
            student = new Student("Changed: " + student.name);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Test passing class (reference type) by reference:");
            var s = new Student("Nakov");
            Console.WriteLine(s.name);
            IncorrectModifyStudent(s);
            Console.WriteLine(s.name);
            ModifyStudent(ref s);
            Console.WriteLine(s.name);
            Console.WriteLine();

            Console.WriteLine("Test passing struct (value type) by reference:");
            var p = new Point { x = 5, y = -8 };
            Console.WriteLine("p=({0},{1})", p.x, p.y);
            MultiplyPoint.IncorrectMultiplyBy2(p);
            Console.WriteLine("p=({0},{1})", p.x, p.y);
            MultiplyPoint.MultiplyBy2(ref p);
            Console.WriteLine("p=({0},{1})", p.x, p.y);
        }
    }
}
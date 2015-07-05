namespace CustomStackExample
{
    using System;

    internal class CustomStackExample
    {
        private static void Main()
        {
            var studentStack = new CustomStack<Student>();
            studentStack.Push(new Student("Pesho", 22));
            studentStack.Push(new Student("Penka", 41));
            studentStack.Push(new Student("Gosho", 7));
            studentStack.Push(new Student("Kuci", 15));

            Console.WriteLine(studentStack.Min().Name);

            var intStack = new CustomStack<int>();

            intStack.Push(4);
            intStack.Push(5);
            intStack.Push(14);
            intStack.Push(42);
            intStack.Push(455);

            intStack.Pop();
            intStack.Pop();

            Console.WriteLine(intStack.Min());

            intStack.Clear();

            Console.WriteLine(intStack.Count);
            Console.WriteLine(intStack.IsEmpty);
            Console.WriteLine(intStack);
        }
    }
}
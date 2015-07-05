using System;

public class ProtectTheObjectStateDemo
{
    private static void Main()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();

        Console.Write("Enter your age: ");
        var age = int.Parse(Console.ReadLine());

        try
        {
            var person = new Person(name, age);
            Console.WriteLine("Hello, {0}!", person.Name);
            Console.WriteLine("Your age is {0}.", person.Age);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Cannot create person object: " + ex);
        }
    }
}
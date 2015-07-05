using System;

public class Dog : Mammal
{
    public Dog(string name, int age, string breed)
        : base(name, age)
    {
        this.Breed = breed;
    }

    public string Breed { get; private set; }

    internal void WagTail()//INTERNAL-acces from the assembly(c# project)
    {
        Console.WriteLine(
            "{0} is {1} wagging his {2}-aged tail ...",
            this.Name,
            this.Breed,
            this.Age);

        //this.Walk(); // This will successfully compile - Walk() is protected, because Dog is inheritor of Mammal
        //this.Talk(); // This will not compile - Talk() is private
        //this.Name = "Doggy"; // This will not compile - Name.set is private
    }
}

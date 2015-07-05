using System;

class Dog
{
    //Fields
    private string name;
    private string breed;

    //Constructor
    public Dog()
    { 
    }
    //Constructor
    public Dog(string name, string breed)
    { 
        this.name = name;
        this.breed = breed; 
    }
    //Property
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    //Property
    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }
    //Method
    public void SayBau()
    {
        Console.WriteLine("{0} said: Bauuuuuu!", 
			this.name ?? "[unnamed dog]");
    }
} 

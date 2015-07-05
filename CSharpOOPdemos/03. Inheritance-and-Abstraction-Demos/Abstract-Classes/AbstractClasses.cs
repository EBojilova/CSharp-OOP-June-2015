using System;

public class AbstractClasses
{
    public static void Main()
    {
        Turtle turtle = new Turtle();
        Console.WriteLine(turtle);
        Console.WriteLine("The {0} can go {1} km/h ", turtle.GetName(), turtle.Speed);

        Console.WriteLine();

        Cheetah cheetah = new Cheetah();
        Console.WriteLine(cheetah);
        Console.WriteLine("The {0} can go {1} km/h ", cheetah.GetName(), cheetah.Speed);

        Console.WriteLine();

        Tomcat tomcat = new Tomcat();
        Console.WriteLine(tomcat);
        Console.WriteLine("The {0} can go {1} km/h ", tomcat.GetName(), tomcat.Speed);
        tomcat.SayMyaau();

        Console.WriteLine();

        Kitten kitten = new Kitten();
        Console.WriteLine(kitten);
        Console.WriteLine("The {0} can go {1} km/h ", kitten.GetName(), kitten.Speed);
        kitten.Breed = "siamska";//Ot dopalnitelnoto Property ot Cat
        Console.WriteLine("The breed of the {0} is {1}", kitten.GetName(), kitten.Breed);
        kitten.SayMyaau();

        // This will not compile (Cat is abstract -> cannot be instantiated)
        //Cat cat = new Cat();
    }
}

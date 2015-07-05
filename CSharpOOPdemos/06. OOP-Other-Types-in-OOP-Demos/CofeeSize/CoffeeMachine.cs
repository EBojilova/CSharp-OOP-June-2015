using System;

namespace CofeeSize
{
    public class CoffeeMachine
    {
        private static void Main()
        {
            var normalCoffee = new Coffee(CoffeeSize.Normal);
            var doubleCoffee = new Coffee(CoffeeSize.Double);

            Console.WriteLine("The {0} coffee is {1} ml.", normalCoffee.Size, (int)normalCoffee.Size);
            Console.WriteLine("The {0} coffee is {1} ml.", doubleCoffee.Size, (int)doubleCoffee.Size);
        }
    }
}
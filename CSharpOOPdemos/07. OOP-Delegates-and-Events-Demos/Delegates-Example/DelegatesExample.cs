namespace Delegates_Example
{
    using System;

    // Declaration of a delegate
    public delegate void SimpleDelegate(string param);

    public class DelegatesExample
    {
        private static void Main()
        {
            // Instantiate the delegate
            SimpleDelegate d = TestMethod;

            // The above can be written in a shorter way
            d = TestMethod;
            d += Print; // dobavia se i vtori method, koto se izvikva sled parvia
            d += Console.WriteLine; // prisvoiavame i treti statichen method, kato mu mahame skobkite

            // Invocation of the method, pointed by delegate
            d("test");
        }

        private static void TestMethod(string param)
        {
            Console.WriteLine("I was called by a delegate and I am TestMethod, with parameter \"{0}\".", param);
        }

        private static void Print(string param)
        {
            Console.WriteLine("I was called by a delegate and I am Print method with parameter \"{0}\".", param);
        }
    }
}
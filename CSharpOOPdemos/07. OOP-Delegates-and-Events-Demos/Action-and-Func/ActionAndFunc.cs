namespace Action_And_Func
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public class ActionAndFunc
    {
        private static void Main()
        {
            Func<string, int> intParseFunction = int.Parse;  // int. Parse ima signatura kato Func<string, int>: priema string i vrasta int

            var num = intParseFunction("10");

            Action<int> printNumberAction = Console.WriteLine; // Console.WriteLine ima mnogo overloadi i moje da priema razlichni tipove, dokato s Action nie go zadaljavame da e int tipa

            printNumberAction(num);

            Execute(intParseFunction, printNumberAction, "-50");
            Execute(double.Parse, Console.WriteLine, "3.14");

            Action<string, int> printNameAge = (name, age) =>
                {
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Age: " + age);
                };

            printNameAge("Pesho", 5);

            Func<string> magic = () => { return "Magic"; }; // Func ne priema parametri, a samo vrasta string Magic

            Console.WriteLine(magic);
            Console.WriteLine(magic());

            int[] list = { 1, 2, 3 };
            var even = list.Where(n => n % 2 == 0); // vatre v skobite e new Func<int, bool>(), priema int i vrasta bool
        }

        private static void Execute<T1, T2>(Func<T1, T2> func, Action<T2> action, T1 value)
        {
            action(func(value));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

internal class PredicatesExample
{
    private static void Main()
    {
        var elements = new List<int> { 40, 50, 60, 5, 10, 20, 30 };

        // Lambda expression with body
        var divisorsWithoutRemainder = elements.Where(delegate(int x) { return x % 3 == 0; });

        // Inline lambda expression
        divisorsWithoutRemainder = elements.Where(x => x % 3 == 0);

            // Where moje da se zameni s FindAll, rabotiat po indentichen nachin, no na edinia se podava Func<int, bool> a na drugia Predicate<int>, koito vrasta bool, no nas ne ni kasae

        // Passing method that is Func<int, bool>
        divisorsWithoutRemainder = elements.Where(DividesByThree);

        // Passing Func<int, bool> delegate
        Func<int, bool> dividesByThreePredicate = DividesByThree;
        divisorsWithoutRemainder = elements.Where(dividesByThreePredicate);

        Console.WriteLine(string.Join(", ", divisorsWithoutRemainder));

        var towns = new List<string> { "Sofia", "Burgas", "Plovdiv", "Varna", "Ruse", "Sopot", "Silistra" };

        // var townsWithS = towns.FindAll(delegate(string town) { return town.StartsWith("S"); }); //stariat nachin
        var townsWithS = towns.FindAll(town => town.StartsWith("S"));
        foreach (var town in townsWithS)
        {
            Console.WriteLine(town);
        }
    }

    private static bool DividesByThree(int num)
    {
        return num % 3 == 0;
    }
}
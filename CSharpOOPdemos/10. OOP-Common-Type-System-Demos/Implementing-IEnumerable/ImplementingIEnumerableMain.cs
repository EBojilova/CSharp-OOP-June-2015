namespace ImplementingIEnumerable
{
    using System;
    using System.Collections.Generic;

    internal class ImplementingIEnumerableMain
    {
        private static void Main()
        {
            // LinkedList<string> -sasto moje zaradi polimorfizma
            IEnumerable<string> list = new LinkedList<string>(
                "1st element", 
                new LinkedList<string>("2nd element", new LinkedList<string>("3rd element")));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // ot metoda v LinkedList
            var enumerator = list.GetEnumerator();

            // pak se vliza v sastiat method, v koito i otogore vlizahme, defakto dolnite redove zamestvat foreacha
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            // enumerator.Reset();
            var nums = new CustomList<int>();
            nums.Add(5);
            nums.Add(2);
            nums.Add(4);
            nums.Add(2);
            nums.Add(1);
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
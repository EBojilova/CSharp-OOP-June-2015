namespace _3.ObjectCloning
{
    using System;

    internal class ObjectCloning
    {
        private static void Main()
        {
            var initialList1 = new LinkedList<string>(
                "Old fellow John", 
                new LinkedList<string>("Granny Yaga", new LinkedList<string>("King Kiro")));

            var deeplyClonedList = initialList1.Clone();
            deeplyClonedList.Value = "1st changed";
            deeplyClonedList.NextLinkedList.Value = "2nd changed";

            Console.WriteLine("initial list1 = {0}", initialList1);
            Console.WriteLine("deeply cloned list = {0}", deeplyClonedList);

            Console.WriteLine();

            var initialList = new LinkedList<string>(
                "Old fellow John",
                new LinkedList<string>("Granny Yaga", new LinkedList<string>("King Kiro")));

            var shallowCopy = initialList.ShallowCopy();
            shallowCopy.Value = "1st changed";
            shallowCopy.NextLinkedList.Value = "2nd changed";

            Console.WriteLine("initial list = {0}", initialList);
            Console.WriteLine("shallow cloned list = {0}", shallowCopy);

            Console.WriteLine();

            initialList = new LinkedList<string>(
                "Old fellow John", 
                new LinkedList<string>("Granny Yaga", new LinkedList<string>("King Kiro")));

            // ne se promenia intial list, tai kato sa stringove i te sa immutable
            var memberwiseCopy = initialList.MemberwiseCopy();
            memberwiseCopy.Value = "1st changed";
            memberwiseCopy.NextLinkedList.Value = "2nd changed";

            Console.WriteLine("initial list = {0}", initialList);
            Console.WriteLine("memberwise cloned list = {0}", memberwiseCopy);
        }
    }
}
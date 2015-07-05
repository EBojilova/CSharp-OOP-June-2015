namespace DynamicType
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    internal class Dynamic
    {
        private static void Main(string[] args)
        {
            // Queue<int>
            // using dynamic for classes
            dynamic student = new Student();
            student.Name = "Pesho";
            Console.WriteLine(student.Name);

            // using dynamic without having dynamic all over the place
            var result = Sum<int>(5, 6); // generic method 
            var decimalResult = Sum<decimal>(15.6M, 16.15M);
            var text = Sum<string>("pesho", "gosho");

            Console.WriteLine(result);
            Console.WriteLine(text);
            Console.WriteLine(decimalResult);

            // using dynamic to compare types
            var comparing = Compare(5, 6);

            // comparing = Compare("pesho", "gosho"); // this causes exception

            // using dynamic expanding object
            dynamic expObj = new ExpandoObject(); //avtomatichno moje da prisvoiava kakvito iskame propertita, beza da pisheme kod
            expObj.Result = 5;
            Console.WriteLine("Result: " + expObj.Result);
            expObj.FirstName = "Pesho";
            expObj.LastName = "Goshovski";
            expObj.SayHello = new Func<string>(() => { return "I am " + expObj.FirstName + " " + expObj.LastName; }); // delegat

            Console.WriteLine(expObj.SayHello());

            // using ExpandoObject as Dictionary<TPropertyName, TPropertyValue>
            var properties = (IDictionary<string, object>)expObj; //kastvame go kam dictionary(value moje da e dynamic ili object)
            properties.Add("Age", 10);
            properties.Add("SayAge", new Func<string>(() => { return "My age is " + properties["Age"]; }));
            Console.WriteLine(expObj.SayAge());

            properties.Add("ChangeAge", new Action<int>(age => { properties["Age"] = age; }));
            expObj.ChangeAge(20);
            Console.WriteLine(expObj.SayAge());

            Console.WriteLine("-----------------------------");
            foreach (var pair in properties)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
            Console.WriteLine("-----------------------------");

            // this will not compile
            dynamic someObj = new ExpandoObject();
            someObj.Result = "Pesho";
            Console.WriteLine(someObj.Result);
        }

        private static T Sum<T>(dynamic first, dynamic second)
        {
            return first + second;
        }

        private static int Compare(dynamic first, dynamic second)
        {
            if (first == second)
            {
                return 0;
            }

            if (first < second)
            {
                return -1;
            }

            return 1;
        }
    }
}
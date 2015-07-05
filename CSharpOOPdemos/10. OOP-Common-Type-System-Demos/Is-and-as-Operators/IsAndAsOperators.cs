namespace IsAndAsOperators
{
    using System;

    using _2.IsAndAsOperators;

    internal class PalyWithOperatorsIsAndAs
    {
        private static void Main(string[] args)
        {
            object objBase = new Shape();
            if (objBase is Shape)
            {
                Console.WriteLine("objBase is Shape");
            }

            // Result: objBase is Shape
            if (!(objBase is Triangle))
            {
                Console.WriteLine("objBase is not Triangle");
            }

            // Result : objBase is not Triangle
            if (objBase is object)
            {
                Console.WriteLine("objBase is System.Object");
            }

            // Result : objBase is System.Object

            // "dynamic" is internally System.Object
            // but with runtime binding of the operations
            if (objBase is dynamic)
            {
                Console.WriteLine("objBase is dynamic");
            }

            // Result: objBase is dynamic
            var b = objBase as Shape;
            Console.WriteLine("b = {0}", b.GetType().Name);

            // Result: b = Shape
            var d = objBase as Triangle;
            if (d == null)
            {
                Console.WriteLine("d is null");
            }

            // Result: d is null
            var o = objBase;
            Console.WriteLine("o = {0}", o.GetType().Name);

            // Result: o = Shape
            var der = new Triangle();
            Shape bas = der;
            Console.WriteLine("bas = {0}", bas.GetType().Name);

            // Result: bas = Triangle
            var dyn = objBase;
            Console.WriteLine("dyn = {0}", dyn.GetType().Name);

            // Result: o = Shape
        }
    }
}
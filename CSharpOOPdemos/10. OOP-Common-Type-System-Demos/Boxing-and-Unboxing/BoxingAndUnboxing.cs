namespace BoxingAndUnboxing
{
    using System;

    internal class TestBoxingUnboxing
    {
        private static void Main()
        {
            var p1 = new Point();
            Console.WriteLine("p1={0}", p1); // p1=(0,0)

            IMovable p1mov = p1; // p1 si boxed, because IMovable is reference type
            var p2mov = p1mov; // p2mov sasto e IMovable i adresa i sochi kam sastoto miasto v pametta kato p1mov

            // p1mov is not boxed second time,
            // because it is already boxed
            var p2 = (Point)p2mov; // p2mov is unboxed
            p1.Move(-100, -100);
            p2.Move(100, 100); 
            Console.WriteLine("p1 is moved to {0}", p1); // p1=(-100,-100)
            Console.WriteLine("p2 is moved to {0}", p2); // p2=(100,100)

            p1mov.Move(5, 5);
            Console.WriteLine("p1mov is moved to {0} ", p1mov); // p1mov=(5,5)
            Console.WriteLine("p2mov is also moved to {0}", p2mov); // p2mov=(5,5)            
        }
    }
}
namespace Virtual_Methods
{
    using System;

    public class WrongFigure : Figure
    {
        public new void Draw()//ne se izpalniava, izapalniava se skritiat method ot Figure
        {
            Console.WriteLine("This method hides inherited member, does not override it!");
        }
    }
}

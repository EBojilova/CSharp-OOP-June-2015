using System;

public class Square : Figure
{
    public double Size { get; set; }

    public override double CalcSurface()
    {
        return this.Size * this.Size;
    }

    public override string ToString()//override na virtual- pravilno
    {
       return "I am square.";
    }

    //public new string ToString()//NE Е PRAVILNO-taka skrivam(hide) predishnia method s new
    //{
    //    return "I am square."; 
    //}
}

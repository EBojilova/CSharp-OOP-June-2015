using System;

public abstract class Figure // moje da e interface, tai kato ne sadarja danni
{
    public abstract double CalcSurface();// tai kato e abstract zadaljitelno e da se override i implementira v naslednicte

    public virtual string ToString()//tai kato e virtyal moje i da se override v naslednicite, moje i da ne se
    {
        return "I am UNKNOWN figure.";
    }
}
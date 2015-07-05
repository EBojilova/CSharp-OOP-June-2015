using System;

public class Creature//(sazdanienaie)nai-visoko v jerarhiata
{
    public Creature(string name)
    {
        this.Name = name;
    }

    protected string Name { get; private set; }//PROTECTED(vaji samo za get) i ima PRIVATE set- moga da getvam imeto samo v tozi klas i klasovete naslednci, a moga da go setvam samo v tekustia klas

    private void Talk()//PRIVATE
    {
        Console.WriteLine("I am creature ...");
    }

    protected void Walk()//PROTECTED
    {
        Console.WriteLine("Walking, walking, walking ....");
    }
}

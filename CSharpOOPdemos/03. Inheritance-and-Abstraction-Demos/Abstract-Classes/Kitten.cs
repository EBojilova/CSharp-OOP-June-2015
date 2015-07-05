public class Kitten : Cat
{
    //Ipplementria abstractnoto Property ot Animal
    public override int Speed
    {
        get
        {
            return 5;
        }
    }
    //Implemmentira abstractnia method ot Animal
    public override string GetName()
    {
        return "kitten";
    }
    //Implementria abstactnia class ot Cat
    public override void SayMyaau()
    {
        System.Console.WriteLine("Kitten miau, miaau");
    }
}

public class Tomcat : Cat
{
    //Ipplementria abstractnoto Property ot Animal
    public override int Speed
    {
        get
        {
            return 20;
        }
    }
    //Implemmentira abstractnia method ot Animal
    public override string GetName()
    {
        return "tomcat";
    }
    //Implementria abstactnia class ot Cat
    public override void SayMyaau()
    {
        System.Console.WriteLine("Tomcat muaaaaaaaau");
    }
}

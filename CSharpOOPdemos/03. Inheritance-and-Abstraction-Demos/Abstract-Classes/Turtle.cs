public class Turtle : Animal
{
    //Ipplementria abstractnoto Property ot Animal
    public override int Speed
    {
        get
        {
            return 1;
        }
    }
    //Implemmentira abstractnia method ot Animal
    public override string GetName()
    {
        return "turtle";
    }
}

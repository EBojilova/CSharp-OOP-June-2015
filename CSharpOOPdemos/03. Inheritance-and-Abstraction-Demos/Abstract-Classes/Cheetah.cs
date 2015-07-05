public class Cheetah : Animal
{
    //Ipplementria abstractnoto Property ot Animal
    public override int Speed
    {
        get
        {
            return 100;
        }
    }

    //Implemmentira abstractnia method ot Animal
    public override string GetName()
    {
        return "cheetah";
    }
}

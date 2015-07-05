namespace WinterIsComing.Core.Commands
{
    using WinterIsComing.Contracts;

    public class WinterCameCommand : AbstractCommand
    {
        public WinterCameCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.Engine.Stop();
        }
    }
}
namespace WinterIsComing.Core.Commands
{
    using System;
    using System.Linq;

    using WinterIsComing.Contracts;

    public class StatusCommand : AbstractCommand
    {
        public StatusCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var unitName = commandArgs[1];

            var unit = this.Engine.Units.First(u => u.Name == unitName);

            Console.WriteLine(unit.ToString());
        }
    }
}
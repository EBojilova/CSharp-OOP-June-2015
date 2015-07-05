namespace WinterIsComing.Core.Commands
{
    using System;

    using WinterIsComing.Contracts;
    using WinterIsComing.Models;

    public class SpawnCommand : AbstractCommand
    {
        public SpawnCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var unitType = (UnitType)Enum.Parse(typeof(UnitType), commandArgs[1]);
            var unitName = commandArgs[2];
            var x = int.Parse(commandArgs[3]);
            var y = int.Parse(commandArgs[4]);

            var unit = UnitFactory.Create(unitType, unitName, x, y);

            this.Engine.InsertUnit(unit);
            this.Engine.UnitContainer.Add(unit);
            this.Engine.OutputWriter.Write(string.Format(GlobalMessages.UnitSpawned, unitName));
        }
    }
}
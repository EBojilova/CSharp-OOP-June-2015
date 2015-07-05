namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            ////INPUT status-report DestinyAscension
            ////--DestinyAscension - Dreadnought
            ////(Destroyed)
            ////var command = commandArgs[0];
            var shipName = commandArgs[1];
            var ship = this.FindShipByName(shipName);
            Console.WriteLine(ship.ToString());
        }
    }
}
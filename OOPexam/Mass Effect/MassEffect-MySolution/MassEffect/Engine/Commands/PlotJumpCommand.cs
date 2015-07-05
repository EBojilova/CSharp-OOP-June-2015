namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            ////INPUT plot-jump Normandy Artemis-Tau
            ////OUTPUT Normandy jumped from Serpent-Nebula to Artemis-Tau
            ////var command = commandArgs[0];
            var shipName = commandArgs[1];
            var nextLocationStr = commandArgs[2];
            var ship = this.FindShipByName(shipName);
            this.ValidateAlive(ship);
            var prevLocation = ship.Location;
            var nextLocation = this.GameEngine.Galaxy.GetStarSystemByName(nextLocationStr);
            if (prevLocation == nextLocation)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, ship.Location.Name));
            }

            this.GameEngine.Galaxy.TravelTo(ship, nextLocation);
            Console.WriteLine(Messages.ShipTraveled, ship.Name, prevLocation.Name, nextLocation.Name);
        }
    }
}
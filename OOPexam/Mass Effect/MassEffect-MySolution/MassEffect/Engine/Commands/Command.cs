namespace MassEffect.Engine.Commands
{
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        public IStarship FindShipByName(string shipName)
        {
            return this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
        }

        protected void ValidateAlive(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
        }
    }
}
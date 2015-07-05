namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            ////INPUT create Frigate Normandy Serpent-Nebula ThanixCannon
            ////OUTPUT Created Frigate Normandy
            ////var command = commandArgs[0];
            var shipTypeStr = commandArgs[1];
            var shipName = commandArgs[2];
            var starSystem = commandArgs[3];
            var shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);
            if (shipAlreadyExists)
            {
                throw new ArgumentException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(starSystem);
            var shipType = (StarshipType)Enum.Parse(typeof(StarshipType), shipTypeStr);
            var ship = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            for (var i = 4; i < commandArgs.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(commandArgs[i]))
                {
                    var enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);
                    var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                    ship.AddEnhancement(enhancement);
                }
            }

            this.GameEngine.Starships.Add(ship);
            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
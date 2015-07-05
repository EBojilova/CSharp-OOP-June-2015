namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using MassEffect.Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            ////INPUT system-report Hades-Gamma
            ////OUTPUT ....
            ////var command = commandArgs[0];
            var starSystemStr = commandArgs[1];
            var starSystem = this.GameEngine.Galaxy.GetStarSystemByName(starSystemStr);
            var intact =
                this.GameEngine.Starships.Where(s => s.Location == starSystem)
                    .Where(s => s.Health > 0)
                    .OrderByDescending(s => s.Health)
                    .ThenByDescending(s => s.Shields);
            var destroyed =
                this.GameEngine.Starships.Where(s => s.Location == starSystem)
                    .Where(s => s.Health <= 0)
                    .OrderBy(s => s.Name);
            var sb = new StringBuilder();
            sb.AppendLine("Intact ships:");
            if (intact.Any())
            {
                foreach (var ship in intact)
                {
                    sb.AppendLine(ship.ToString());
                }
            }
            else
            {
                sb.AppendLine("N/A");
            }

            sb.AppendLine("Destroyed ships:");
            if (destroyed.Any())
            {
                foreach (var ship in destroyed)
                {
                    sb.AppendLine(ship.ToString());
                }
            }
            else
            {
                sb.AppendLine("N/A");
            }

            Console.Write(sb.ToString());
        }
    }
}
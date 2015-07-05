namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            ////INPUT attack Normandy DestinyAscension
            ////OUTPUT Normandy attacked DestinyAscension
            ////var command = commandArgs[0];
            var attackerName = commandArgs[1];
            var targetName = commandArgs[2];
            var attacker = this.FindShipByName(attackerName);
            var target = this.FindShipByName(targetName);
            this.ValidateAlive(attacker);
            this.ValidateAlive(target);
            if (attacker.Location != target.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            target.RespondToAttack(attacker.ProduceAttack());
            Console.WriteLine(Messages.ShipAttacked, attackerName, targetName);
            if (target.Health <= 0)
            {
                Console.WriteLine(Messages.ShipDestroyed, target.Name);
                target.Health = 0;
            }

            if (target.Shields < 0)
            {
                target.Shields = 0;
            }
        }
    }
}
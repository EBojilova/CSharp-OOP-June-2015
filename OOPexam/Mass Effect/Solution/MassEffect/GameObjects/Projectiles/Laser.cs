﻿namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            int remainder = this.Damage - targetShip.Shields;
            targetShip.Shields -= this.Damage;

            if (remainder > 0)
            {
                targetShip.Health -= remainder;
            }
        }
    }
}

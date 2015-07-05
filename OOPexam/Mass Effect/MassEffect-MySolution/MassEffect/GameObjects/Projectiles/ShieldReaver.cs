namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    internal class ShieldReaver : Projectile
    {
        public ShieldReaver(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ////removes health from the ship equal to the projectile's damage. It also removes shields from the ship equal to 2x the projectile's damage.
            ship.Health -= this.Damage;
            ship.Shields -= this.Damage * 2;
        }
    }
}
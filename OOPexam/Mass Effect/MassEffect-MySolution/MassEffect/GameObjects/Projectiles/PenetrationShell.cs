namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    internal class PenetrationShell : Projectile
    {
        public PenetrationShell(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ////removes health from the ship equal to the projectile's damage
            ship.Health -= this.Damage;
        }
    }
}
namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    internal class Cruiser : Ship
    {
        ////start health 100, shields 100, damage 50 and fuel 300. Shoots a PenetrationShell with damage equal to its own damage
        private const int DefHealth = 100;

        private const int DefShields = 100;

        private const int DefDamage = 50;

        private const double DefFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, DefHealth, DefShields, DefDamage, DefFuel, location)
        {
            this.StarshipType = StarshipType.Cruiser;
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
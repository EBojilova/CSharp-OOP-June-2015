namespace MassEffect.GameObjects.Ships
{
    using System;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    internal class Frigate : Ship
    {
        //// health 60, shields 50, damage 30 and fuel 220. Shoots a ShieldReaver with damage equal to its own damage.
        private const int DefHealth = 60;

        private const int DefShields = 50;

        private const int DefDamage = 30;

        private const double DefFuel = 220;

        public Frigate(string name, StarSystem location)
            : base(name, DefHealth, DefShields, DefDamage, DefFuel, location)
        {
            this.StarshipType = StarshipType.Frigate;
        }

        public int ProjectilesFired { get; set; }

        public override IProjectile ProduceAttack()
        {
            this.ProjectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return string.Format(
                    "{0}{1}-Projectiles fired: {2}", 
                    base.ToString(), 
                    Environment.NewLine, 
                    this.ProjectilesFired);
            }

            return base.ToString();
        }
    }
}
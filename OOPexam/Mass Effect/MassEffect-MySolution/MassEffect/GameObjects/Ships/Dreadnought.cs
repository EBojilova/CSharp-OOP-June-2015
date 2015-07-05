namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    internal class Dreadnought : Ship
    {
        ////has start health 200, shields 300, damage 150 and fuel 700. Shoots a Laser with damage equal to half its shields + own damage. 
        ////Responds to an attack by raising its shields by 50 before the attack and removes them after it
        private const int DefHealth = 200;

        private const int DefShields = 300;

        private const int DefDamage = 150;

        private const double DefFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefHealth, DefShields, DefDamage, DefFuel, location)
        {
            this.StarshipType = StarshipType.Cruiser;
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields / 2);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -= 50;
        }
    }
}
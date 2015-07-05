namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    internal class WolfRaider : Creature
    {
        //// attack 8, defense 5, health points 10, damage 3.5 , and has the following specialties:
        ////DoubleDamage specialty for 7 rounds
        private const int DefaultAttack = 8;

        private const int DefaultDefense = 5;

        private const int DefaultlHealth = 10;

        private const decimal DefaultDamage = 3.5m;

        private const int DoubleDamageRounds = 7;

        public WolfRaider()
            : base(DefaultAttack, DefaultDefense, DefaultlHealth, DefaultDamage)
        {
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}
namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;

    internal class Goblin : Creature
    {
        // attack 4, defense 2, health points 5 and damage 1.5 and has no specialties.
        private const int DefaultAttack = 4;

        private const int DefaultDefense = 2;

        private const int DefaultlHealth = 5;

        private const decimal DefaultDamage = 1.5m;

        public Goblin()
            : base(DefaultAttack, DefaultDefense, DefaultlHealth, DefaultDamage)
        {
        }
    }
}
namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    internal class Griffin : Creature
    {
        //// attack 8, defense 8, health points 25 and damage 4.5, and has the following specialties:
        ////DoubleDefenseWhenDefending for 5 rounds
        ////AddDefenseWhenSkip with 3 defense points
        ////Hate specialty to WolfRaider creatures
        private const int DefaultAttack = 8;

        private const int DefaultDefense = 8;

        private const int DefaultlHealth = 25;

        private const decimal DefaultDamage = 4.5m;

        private const int DoubleDefenseWhenDefendingRounds = 5;

        private const int DefenseWhenSkipPoints = 3;

        public Griffin()
            : base(DefaultAttack, DefaultDefense, DefaultlHealth, DefaultDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(DoubleDefenseWhenDefendingRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(DefenseWhenSkipPoints));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
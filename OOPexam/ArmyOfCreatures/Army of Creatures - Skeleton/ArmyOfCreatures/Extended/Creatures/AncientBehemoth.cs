namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    internal class AncientBehemoth : Creature
    {
        //// attack 19, defense 19, health points 300 and damage 40, and has the following specialties:
        ////ReduceEnemyDefenseByPercentage specialty with 80% defense reduction
        ////DoubleDefenseWhenDefending specialty for 5 rounds
        private const int DefaultAttack = 19;

        private const int DefaultDefense = 19;

        private const int DefaultlHealth = 300;

        private const decimal DefaultDamage = 40m;

        private const int EnemyDefenseReductionPercentage = 80;

        private const int DoubleDefenseWhenDefendingRounds = 5;

        public AncientBehemoth()
            : base(DefaultAttack, DefaultDefense, DefaultlHealth, DefaultDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(EnemyDefenseReductionPercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(DoubleDefenseWhenDefendingRounds));
        }
    }
}
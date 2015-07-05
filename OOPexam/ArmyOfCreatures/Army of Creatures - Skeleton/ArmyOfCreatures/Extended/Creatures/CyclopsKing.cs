namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    internal class CyclopsKing : Creature
    {
        //// attack 17, defense 13, health points 70, damage 18, and has the following specialties:
        ////AddAttackWhenSkip with 3 attack points for each skip action.
        ////DoubleAttackWhenAttacking for 4 rounds
        ////DoubleDamage for 1 round
        private const int DefaultAttack = 17;

        private const int DefaultDefense = 13;

        private const int DefaultlHealth = 70;

        private const decimal DefaultDamage = 18m;

        private const int AttackWhenSkipPoints = 3;

        private const int DoubleAttackWhenAttackingRounds = 4;

        private const int DoubleDamageRounds = 1;

        public CyclopsKing()
            : base(DefaultAttack, DefaultDefense, DefaultlHealth, DefaultDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AttackWhenSkipPoints));
            this.AddSpecialty(new DoubleAttackWhenAttacking(DoubleAttackWhenAttackingRounds));
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}
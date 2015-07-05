namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class Archangel : Creature
    {
        private const int DefaultArchangelAttack = 20;
        private const int DefaultArchangelDefense = 20;
        private const int DefaultArchangelHealth = 200;
        private const decimal DefaultArchangelDamage = 50;

        public Archangel()
            : base(DefaultArchangelAttack, DefaultArchangelDefense, DefaultArchangelHealth, DefaultArchangelDamage)
        {
            this.AddSpecialty(new Hate(typeof(Devil)));
            this.AddSpecialty(new Hate(typeof(ArchDevil)));
            this.AddSpecialty(new Resurrection());
        }
    }
}

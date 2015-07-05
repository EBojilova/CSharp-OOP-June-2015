namespace WinterIsComing.Models.Spells
{
    internal class Cleave : Spell
    {
        ////costs 15 energy
        private const int DefEnergy = 15;

        public Cleave(int damage)
            : base(damage, DefEnergy)
        {
        }
    }
}
namespace WinterIsComing.Models.Spells
{
    internal class Blizzard : Spell
    {
        ////costs 40 energy
        private const int DefEnergy = 40;

        public Blizzard(int damage)
            : base(damage, DefEnergy)
        {
        }
    }
}
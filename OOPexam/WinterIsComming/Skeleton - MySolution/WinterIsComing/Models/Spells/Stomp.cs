namespace WinterIsComing.Models.Spells
{
    internal class Stomp : Spell
    {
        ////costs 10 energy
        private const int DefEnergy = 10;

        public Stomp(int damage)
            : base(damage, DefEnergy)
        {
        }
    }
}
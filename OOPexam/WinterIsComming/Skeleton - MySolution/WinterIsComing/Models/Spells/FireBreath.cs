namespace WinterIsComing.Models.Spells
{
    internal class FireBreath : Spell
    {
         ////costs 30 energy
        private const int DefEnergy = 30;

        public FireBreath(int damage)
            : base(damage, DefEnergy)
        {
        }
    }
}
namespace MassEffect.GameObjects.Enhancements
{
    internal class KineticBarrier : Enhancement
    {
        /////gives a ship bonus 100 shields
        private const int DefShieldBonus = 100;

        private const int DefDamageBonus = 0;

        private const int DefFuelBonus = 0;

        public KineticBarrier(string name)
            : base(name, DefShieldBonus, DefDamageBonus, DefFuelBonus)
        {
            this.EnhancementType = EnhancementType.KineticBarrier;
        }
    }
}
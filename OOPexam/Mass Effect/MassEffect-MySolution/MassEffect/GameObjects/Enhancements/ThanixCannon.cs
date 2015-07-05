namespace MassEffect.GameObjects.Enhancements
{
    internal class ThanixCannon : Enhancement
    {
        /////gives a ship bonus 50 damage
        private const int DefShieldBonus = 0;

        private const int DefDamageBonus = 50;

        private const int DefFuelBonus = 0;
        
        public ThanixCannon(string name)
            : base(name, DefShieldBonus, DefDamageBonus, DefFuelBonus)
        {
            this.EnhancementType = EnhancementType.ThanixCannon;
        }
    }
}
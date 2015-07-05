namespace MassEffect.GameObjects.Enhancements
{
    internal class ExtendedFuelCells : Enhancement
    {
        /////gives a ship bonus 200 fuel
        private const int DefShieldBonus = 0;

        private const int DefDamageBonus = 0;

        private const int DefFuelBonus = 200;

        public ExtendedFuelCells(string name)
            : base(name, DefShieldBonus, DefDamageBonus, DefFuelBonus)
        {
            this.EnhancementType = EnhancementType.ExtendedFuelCells;
        }
    }
}
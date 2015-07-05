namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    internal class Mage : Unit
    {
        ////Default stats: 80 attack points, 80 health points, 40 defense, 120 energy, range 2
        private const int DefAttack = 80;

        private const int DefHealth = 80;

        private const int DefDefense = 40;

        private const int DefEnergy = 120;

        private const int DefRange = 2;

        public Mage(string unitName, int x, int y)
            : base(unitName, x, y, DefAttack, DefHealth, DefDefense, DefEnergy, DefRange)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}
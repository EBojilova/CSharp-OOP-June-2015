namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    internal class IceGiant : Unit
    {
        ////Default stats: 150 attack points, 300 health points, 60 defense, 50 energy, range 1
        private const int DefAttack = 150;

        private const int DefHealth = 300;

        private const int DefDefense = 60;

        private const int DefEnergy = 50;

        private const int DefRange = 1;

        public IceGiant(string unitName, int x, int y)
            : base(unitName, x, y, DefAttack, DefHealth, DefDefense, DefEnergy, DefRange)
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
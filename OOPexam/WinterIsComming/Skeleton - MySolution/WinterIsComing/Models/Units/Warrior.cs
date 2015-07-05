namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    internal class Warrior : Unit
    {
        ////Default stats: 120 attack points, 180 health points, 70 defense, 60 energy, range 1
        private const int DefAttack = 120;

        private const int DefHealth = 180;

        private const int DefDefense = 70;

        private const int DefEnergy = 60;

        private const int DefRange = 1;

        public Warrior(string unitName, int x, int y)
            : base(unitName, x, y, DefAttack, DefHealth, DefDefense, DefEnergy, DefRange)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }
    }
}
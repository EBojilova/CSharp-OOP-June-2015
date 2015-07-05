namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TheSlum.Interfaces;

    internal class Healer : Character, IHeal
    {
        private const int DefaultHealthPoints = 75;

        private const int DefaultDefensePoints = 50;

        private const int DefaultRange = 6;

        private int healingPoints = 60;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, DefaultHealthPoints, DefaultDefensePoints, team, DefaultRange)
        {
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Healing points cannot be negative.");
                }

                this.healingPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target =
                targetsList.Where(x => x.IsAlive)
                    .Where(x => x.Team == this.Team)
                    .Where(x => x != this)
                    .OrderBy(x => x.HealthPoints)
                    .FirstOrDefault();

            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return string.Format("{0}, Healing: {1}", base.ToString(), this.HealingPoints);
        }
    }
}
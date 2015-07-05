namespace WinterIsComing.Models.Units
{
    using System.Text;

    using WinterIsComing.Contracts;

    internal abstract class Unit : IUnit
    {
        private string name;

        private int x;

        private int y;

        protected Unit(
            string unitName, 
            int x, 
            int y, 
            int attackPoints, 
            int healthPoints, 
            int defence, 
            int energy, 
            int range)
        {
            this.Name = unitName;
            this.X = x;
            this.Y = y;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defence;
            this.EnergyPoints = energy;
            this.Range = range;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                Validator.PositonCheck(value);
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                Validator.PositonCheck(value);
                this.y = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.StringCeck(value);
                this.name = value;
            }
        }

        public int Range { get; private set; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; protected set; }

        public override string ToString()
        {
            ////>Alex - Mage at (2,3)
            ////(Dead)
            ////>Emi - Mage at (0,3)
            ////-Health points = 40
            ////-Attack points = 80
            ////-Defense points = 40
            ////-Energy points = 90
            ////-Range = 2
            var sb = new StringBuilder();
            sb.AppendFormat(">{0} - {1} at ({2},{3})", this.Name, this.GetType().Name, this.X, this.Y).AppendLine();
            if (this.HealthPoints > 0)
            {
                sb.AppendFormat("-Health points = {0}", this.HealthPoints).AppendLine();
                sb.AppendFormat("-Attack points = {0}", this.AttackPoints).AppendLine();
                sb.AppendFormat("-Defense points = {0}", this.DefensePoints).AppendLine();
                sb.AppendFormat("-Energy points = {0}", this.EnergyPoints).AppendLine();
                sb.AppendFormat("-Range = {0}", this.Range);
            }
            else
            {
                sb.Append("(Dead)");
            }

            return sb.ToString();
        }
    }
}
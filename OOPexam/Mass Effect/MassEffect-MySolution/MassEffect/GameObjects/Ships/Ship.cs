namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    internal abstract class Ship : IStarship
    {
        private readonly IList<Enhancement> enhancements = new List<Enhancement>();

        protected Ship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
        }

        public StarshipType StarshipType { get; protected set; }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public virtual void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("enhancement", "Enhansment must not be null.");
            }

            this.enhancements.Add(enhancement);
            this.AddEnhansmentBonus(enhancement);
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        private void AddEnhansmentBonus(Enhancement enhancement)
        {
            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));
            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                var enhancementsOutput = "N/A";
                if (this.enhancements.Count > 0)
                {
                    enhancementsOutput = string.Join(", ", this.enhancements.Select(e => e.Name));
                }

                output.Append(string.Format("-Enhancements: {0}", enhancementsOutput));
            }

            return output.ToString();
        }
    }
}
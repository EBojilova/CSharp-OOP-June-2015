namespace RestaurantManager.Models
{
    using System;
    using System.Text;

    using RestaurantManager.Interfaces;

    internal class Drink : Recipe, IDrink
    {
        private const int MaxCalories = 100;

        private const int MaxTimeToPrepare = 20;

        public Drink(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare, MetricUnit.Milliliters)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; private set; }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }

            protected set
            {
                if (value > MaxCalories)
                {
                    throw new ArgumentException(string.Format("The calories in a drink must not be greater than {0}.", MaxCalories));
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }

            protected set
            {
                if (value > MaxTimeToPrepare)
                {
                    throw new ArgumentException(string.Format("The time to prepare a drink must not be greater than {0} minutes.", MaxTimeToPrepare));
                }

                base.TimeToPrepare = value;
            }
        }

        public override string ToString()
        {
            /////Carbonated: <yes / no>
            var isCAarbonated = this.IsCarbonated ? "yes" : "no";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Carbonated: {0}", isCAarbonated).AppendLine();
            return sb.ToString();
        }
    }
}
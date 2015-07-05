namespace RestaurantManager.Models
{
    using System;
    using System.Text;

    using RestaurantManager.Interfaces;

    internal class Meal : Recipe, IMeal
    {
        public Meal(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare,
            bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare, MetricUnit.Grams)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; private set; }

        public virtual void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            ////[VEGAN] ==  Mexican Bean Salad == $7.99
            if (this.IsVegan == false)
            {
                return base.ToString();
            }
            
            var sb = new StringBuilder();
            sb.Append("[VEGAN] ");
            sb.Append(base.ToString());
            return sb.ToString();
        }
    }
}
namespace RestaurantManager.Models
{
    using System;
    using System.Text;

    using RestaurantManager.Interfaces;

    internal class Salad : Meal, ISalad
    {
        public Salad(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; private set; }

        public override void ToggleVegan()
        {
            throw new InvalidOperationException("The salad is only vegan!");
        }

        public override string ToString()
        {
            /////Contains pasta: no
            var containsPasta = this.ContainsPasta ? "yes" : "no";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Contains pasta: {0}", containsPasta).AppendLine();
            return sb.ToString();
        }
    }
}
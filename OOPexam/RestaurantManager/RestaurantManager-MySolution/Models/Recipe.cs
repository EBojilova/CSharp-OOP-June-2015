namespace RestaurantManager.Models
{
    using System.Text;

    using RestaurantManager.Interfaces;

    internal abstract class Recipe : IRecipe
    {
        private int calories;

        private string name;

        private decimal price;

        private int quantityPerServing;

        private int timeToPrepare;

        protected Recipe(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            MetricUnit unit)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
            this.Unit = unit;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringNullEmptyValidator(value, "name");
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                Validator.PositiveValueCheck(value, "price");
                this.price = value;
            }
        }

        public virtual int Calories
        {
            get
            {
                return this.calories;
            }

            protected set
            {
                Validator.PositiveValueCheck(value, "calories");
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }

            private set
            {
                Validator.PositiveValueCheck(value, "quantityPerServing");
                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit { get; private set; }

        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            protected set
            {
                Validator.PositiveValueCheck(value, "timeToPrepare");
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            ////[VEGAN] ==  Mexican Bean Salad == $7.99
            ////Per serving: 300 g, 150 kcal
            ////Ready in 14 minutes
            var sb = new StringBuilder();
            var measurement = this.Unit == MetricUnit.Grams ? "g" : "ml";
            sb.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine();
            sb.AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, measurement, this.Calories).AppendLine();
            sb.AppendFormat("Ready in {0} minutes", this.TimeToPrepare);
            return sb.ToString();
        }
    }
}
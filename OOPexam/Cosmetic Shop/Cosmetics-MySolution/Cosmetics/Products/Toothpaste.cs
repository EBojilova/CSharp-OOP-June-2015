namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Toothpaste : Product, IToothpaste
    {
        private const int MinNameLenght = 4;

        private const int MaxNameLenght = 12;

        private readonly IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            ////* Quantity: {product quantity} ml (when applicable)
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendFormat("  * Ingredients: {0}", this.Ingredients);
            return sb.ToString();
        }

        private void ValidateIngredients(IList<string> ingredientsToCheck)
        {
            foreach (var ingredient in ingredientsToCheck)
            {
                Validator.CheckIfNull(ingredient, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ingredient));
                Validator.CheckIfStringLengthIsValid(
                    ingredient, 
                    MaxNameLenght, 
                    MinNameLenght, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, ingredient, MinNameLenght, MaxNameLenght));
            }
        }
    }
}
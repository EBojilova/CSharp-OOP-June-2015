namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinNameLenght = 3;

        private const int MaxNameLenght = 10;

        private const string CategoryName = "Product name";

        private const int MinBrandLenght = 2;

        private const int MaxBrandLenght = 10;

        private const string BrandName = "Product brand";

        private string brand;

        private string name;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, CategoryName));
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    MaxNameLenght, 
                    MinNameLenght, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, CategoryName, MinNameLenght, MaxNameLenght));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, BrandName));
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    MaxBrandLenght, 
                    MinBrandLenght, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, BrandName, MinBrandLenght, MaxBrandLenght));

                this.brand = value;
            }
        }

        public virtual decimal Price { get; set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            //// - {product brand} – {product name}:
            ////* Price: ${product price}
            ////* For gender: Men/Women/Unisex
            var sb = new StringBuilder();
            sb.AppendFormat("- {0} - {1}:", this.Brand, this.Name).AppendLine();
            sb.AppendFormat("  * Price: ${0:F2}", this.Price).AppendLine();
            sb.AppendFormat("  * For gender: {0}", this.Gender);
            return sb.ToString();
        }
    }
}
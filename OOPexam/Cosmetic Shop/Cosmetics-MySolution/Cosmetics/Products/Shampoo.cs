namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Shampoo : Product, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint mililiters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = mililiters;
            this.Usage = usage;
        }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            ////* Quantity: {product quantity} ml (when applicable)
            ////* Usage: EveryDay/Medical (when applicable)
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendFormat("  * Quantity: {0} ml", this.Milliliters).AppendLine();
            sb.AppendFormat("  * Usage: {0}", this.Usage);
            return sb.ToString();
        }
    }
}
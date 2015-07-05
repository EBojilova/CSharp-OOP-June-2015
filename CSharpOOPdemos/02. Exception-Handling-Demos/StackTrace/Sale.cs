using System;

namespace StackTrace
{
    public class Sale
    {
        private string customer;
        private string product;
        private double price;

        public Sale(string customer, string product, double price)
        {
            this.Customer = customer;
            this.Product = product;
            this.Price = price;
        }

        public string Customer
        {
            get { return this.customer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Customer", "Customer cannot be null");
                }
                this.customer = value;
            }
        }

        public string Product
        {
            get { return this.product; }//ako po pogreshka izvikame this.Product(s glavna bukva) ste stane rekursia i ste ima StackOverFlowException
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product", "Product cannot be null");
                }
                this.product = value;//ako po pogreshka izvikame this.Product(s glavna bukva) ste stane rekursia i ste ima StackOverFlowException
            }
        }

        public double Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    //exceptiona ne e obraboten, toi samo se sazdava i tova saobstenie ste se izpishe za informacia na samia programist, ako gramne programata(t.e. ne e obraboten s try catch exceptiona)
                    throw new ArgumentOutOfRangeException("Price cannot be nagative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("-Customer: {0}, Product: {1}, Price: ${2:F2}",
                this.Customer, this.Product, this.Price);
        }
    }
}

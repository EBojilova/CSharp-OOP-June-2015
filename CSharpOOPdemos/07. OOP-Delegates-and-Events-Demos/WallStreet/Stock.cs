namespace WallStreet
{
    using System;

    public abstract class Stock
    {
        private readonly string symbol;

        private double price;

        protected Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.Price = price;
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                // pri vsiako setvane na nova cena, eventa( i methoda kam nego) ste bade izvikvan
                if (Math.Abs(this.price - value) > 0.001)
                {
                    if (this.StockChangeEvent != null)
                    {
                        this.StockChangeEvent(this, new StockChangedEventArgs(this.price, value)); // ste ni preprati kam methoda, koito e prisvoen na tozi event
                    }

                    this.price = value;
                }
            }
        }

        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public event OnStockChangeEventHandler StockChangeEvent; // eventite sa publichni
    }
}
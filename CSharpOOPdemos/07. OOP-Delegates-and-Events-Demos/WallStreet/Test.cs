namespace WallStreet
{
    using System;

    public class Test
    {
        private static void Main()
        {
            // Create IBM stock
            var ibm = new IBM("IBM", 120.00);

            // Attach annonimos method to StockChangeEvent
            ibm.StockChangeEvent +=
                (stock, args) =>
                    {
                        Console.WriteLine("Price of {0} has changed from {1:F2} to {2:F2}", stock.Symbol, args.OldPrice, args.NewPrice);
                    };

            // Fluctuating prices will fire the event
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
        }
    }
}
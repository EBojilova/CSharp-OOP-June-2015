namespace CofeeSize
{
    public class Coffee
    {
        private readonly CoffeeSize size;

        public Coffee(CoffeeSize size)
        {
            this.size = size;
        }

        public CoffeeSize Size
        {
            get
            {
                return this.size; // bezmisleno e da ima setter, tai kato enum e stoinosten tip i ne moje da e null
            }
        }
    }
}
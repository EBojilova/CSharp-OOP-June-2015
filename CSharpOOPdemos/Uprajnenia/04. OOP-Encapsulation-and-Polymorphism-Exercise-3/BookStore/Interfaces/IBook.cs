namespace BookStore.Interfaces
{
    internal interface IBook
    {
        string Title { get; }

        decimal Price { get; }
    }
}
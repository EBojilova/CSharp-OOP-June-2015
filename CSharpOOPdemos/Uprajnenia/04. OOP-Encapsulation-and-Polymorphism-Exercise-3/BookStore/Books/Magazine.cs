namespace BookStore.Books
{
    using BookStore.Interfaces;

    public class Magazine : IBook
    {
        public string Title { get; private set; }

        public decimal Price { get; private set; }
    }
}
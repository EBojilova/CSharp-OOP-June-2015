namespace BookStore
{
    using BookStore.Engine;
    using BookStore.Interfaces;
    using BookStore.UI;

    public class BookStoreMain
    {
        public static void Main()
        {
            IInputHandler inputHandler = new ConsoleInputHandler();
            IRenderer renderer = new FileRenderer();

            var engine = new BookStoreEngine(renderer, inputHandler);

            engine.Run();
        }
    }
}
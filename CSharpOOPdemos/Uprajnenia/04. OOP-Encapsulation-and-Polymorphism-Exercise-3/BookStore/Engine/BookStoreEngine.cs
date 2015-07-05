namespace BookStore.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using BookStore.Books;
    using BookStore.Interfaces;

    public class BookStoreEngine
    {
        private readonly List<IBook> books;

        private readonly IInputHandler inputHandler;

        private readonly IRenderer renderer;

        private decimal revenue;

        public BookStoreEngine(IRenderer renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.books = new List<IBook>();
            this.revenue = 0;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;
            while (this.IsRunning)
            {
                var command = this.inputHandler.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    this.renderer.WriteLine("Please enter new command. Command cannot be null, empty or whitespace");
                    continue;
                }

                var commandArgs = command.Split();

                var commandResult = this.ExecuteCommand(commandArgs);

                this.renderer.WriteLine(commandResult);
            }

            this.renderer.WriteLine("Total revenue: {0:F2}", this.revenue);
        }

        private string ExecuteCommand(string[] commandArgs)
        {
            switch (commandArgs[0])
            {
                case "add":
                    return this.ExecuteAddBookCommand(commandArgs);
                case "sell":
                    return this.ExecuteSellBookCommand(commandArgs);
                case "remove":
                    return this.ExecuteRemoveBookCommand(commandArgs);
                case "stop":
                    this.IsRunning = false;
                    return "Goodbye!";
                default:
                    return "Unknown command";
            }
        }

        private string ExecuteSellBookCommand(string[] commandArgs)
        {
            var title = commandArgs[1];
            var bookToSellOrRemove = this.books.FirstOrDefault(book => book.Title == title);
            if (bookToSellOrRemove == null)
            {
                return "Book does not exist";
            }

            this.books.Remove(bookToSellOrRemove);
            this.revenue += bookToSellOrRemove.Price;
            return "Book sold";
        }

        private string ExecuteRemoveBookCommand(string[] commandArgs)
        {
            var title = commandArgs[1];
            var bookToSellOrRemove = this.books.FirstOrDefault(book => book.Title == title);
            if (bookToSellOrRemove == null)
            {
                return "Book does not exist";
            }

            this.books.Remove(bookToSellOrRemove);
            return "Book removed";
        }

        private string ExecuteAddBookCommand(string[] commandArgs)
        {
            var title = commandArgs[1];
            var author = commandArgs[2];
            var price = decimal.Parse(commandArgs[3]);
            this.books.Add(new Book(title, author, price));
            return "Book added";
        }
    }
}
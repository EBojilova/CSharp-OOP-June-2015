namespace BookStore.UI
{
    using System;

    using BookStore.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params object[] parameters) // vajno e da e object, za da pokriva vsichki tipove
        {
            Console.WriteLine(message, parameters);
        }
    }
}
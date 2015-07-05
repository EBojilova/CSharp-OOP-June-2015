namespace BookStore.UI
{
    using System;

    using BookStore.Interfaces;

    internal class ConsoleInputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
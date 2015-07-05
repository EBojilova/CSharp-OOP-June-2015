namespace WinterIsComing.Core
{
    using System;

    using WinterIsComing.Contracts;

    public class ConsoleReader : IInputReader
    {
        public string ReadNextLine()
        {
            return Console.ReadLine();
        }
    }
}
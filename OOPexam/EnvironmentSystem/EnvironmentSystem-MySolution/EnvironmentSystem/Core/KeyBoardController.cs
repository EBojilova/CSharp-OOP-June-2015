namespace EnvironmentSystem.Core
{
    using System;

    using EnvironmentSystem.Interfaces;

    internal class KeyBoardController : IController
    {
        public event EventHandler PauseEvent;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    if (this.PauseEvent != null)
                    {
                        this.PauseEvent(this, EventArgs.Empty);
                    }
                }
            }

        }
    }
}
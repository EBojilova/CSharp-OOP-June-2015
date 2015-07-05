namespace EnvironmentSystem.Interfaces
{
    using System;

    public interface IController
    {
        event EventHandler PauseEvent;

        void ProcessInput();
    }
}

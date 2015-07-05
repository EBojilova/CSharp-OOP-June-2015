namespace EnvironmentSystem.Core
{
    using System;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.Objects;

    internal class ExtendedEngine : Engine
    {
        private readonly IController controller;

        private bool isPoused;

        public ExtendedEngine(
            int worldWidth, 
            int worldHeight, 
            IObjectGenerator<EnvironmentObject> objectGenerator, 
            ICollisionHandler collisionHandler, 
            IRenderer renderer, 
            IController controller)
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput(); // ot kontrolera ako ima natisnat Space ste izvikame eventa
            if (!this.isPoused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (object.Equals(obj, null))
            {
                throw new ArgumentNullException("Object cannot be null.");
            }

            base.Insert(obj);
        }

        private void AttachControllerEvents()
        {
            this.controller.PauseEvent += this.ChangePoused; // podavame na eventa metoda
        }

        private void ChangePoused(object sender, EventArgs arg)
        {
            this.isPoused = !this.isPoused;
        }
    }
}
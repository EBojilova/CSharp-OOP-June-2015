namespace WinterIsComing.Core
{
    using System;
    using System.Collections.Generic;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core.Exceptions;

    public sealed class Engine : IEngine
    {
        private readonly ICommandDispatcher commandDispatcher;

        private readonly IInputReader reader;

        private readonly IUnitContainer unitContainer;

        private readonly IUnitEffector unitEffector;

        private readonly ICollection<IUnit> units;

        private readonly IOutputWriter writer;

        private bool isStarted;

        public Engine(
            IUnitContainer unitContainer, 
            IInputReader reader, 
            IOutputWriter writer, 
            ICommandDispatcher commandDispatcher, 
            IUnitEffector unitEffector)
        {
            this.units = new LinkedList<IUnit>();
            this.unitContainer = unitContainer;
            this.writer = writer;
            this.reader = reader;
            this.commandDispatcher = commandDispatcher;
            this.commandDispatcher.Engine = this;
            this.unitEffector = unitEffector;
        }

        public IUnitContainer UnitContainer
        {
            get
            {
                return this.unitContainer;
            }
        }

        public IOutputWriter OutputWriter
        {
            get
            {
                return this.writer;
            }
        }

        public IEnumerable<IUnit> Units
        {
            get
            {
                return this.units;
            }
        }

        public IUnitEffector UnitEffector
        {
            get
            {
                return this.unitEffector;
            }
        }

        public void Start()
        {
            this.commandDispatcher.SeedCommands();
            this.isStarted = true;

            while (this.isStarted)
            {
                var input = this.reader.ReadNextLine();
                var inputArgs = input.Split(' ');

                try
                {
                    this.commandDispatcher.DispatchCommand(inputArgs);
                }
                catch (GameException ex)
                {
                    this.writer.Write(ex.Message);
                }
            }

            this.writer.Flush();
        }

        public void Stop()
        {
            this.isStarted = false;
        }

        public void InsertUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("Unit cannot be null");
            }

            this.units.Add(unit);
        }

        public void RemoveUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("Unit cannot be null");
            }

            this.units.Remove(unit);
        }
    }
}
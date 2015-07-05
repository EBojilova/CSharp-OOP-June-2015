using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine
{
    using MassEffect.Engine.Commands;

    class ExtendedCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
            base.SeedCommands();
        }
    }
}

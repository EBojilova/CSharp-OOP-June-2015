namespace WinterIsComing.Core
{
    using WinterIsComing.Core.Commands;

    internal class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void DispatchCommand(string[] commandArgs)
        {
            base.DispatchCommand(commandArgs);
        }

        public override void SeedCommands()
        {
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
            base.SeedCommands();
        }
    }
}
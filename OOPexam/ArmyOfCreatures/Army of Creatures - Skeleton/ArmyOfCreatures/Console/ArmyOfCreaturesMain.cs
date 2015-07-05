namespace ArmyOfCreatures.Console
{
    using System;
    using System.Globalization;
    using System.Threading;

    using ArmyOfCreatures.Console.Commands;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    public static class ArmyOfCreaturesMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var creaturesFactory = GetCreaturesFactory();
            ILogger logger = new ConsoleLogger();
            var battleManager = GetBattleManager(creaturesFactory, logger);

            ICommandManager commandManager = new CommandManager();

            while (true)
            {
                var commandLine = Console.ReadLine();
                commandManager.ProcessCommand(commandLine, battleManager);
            }
        }

        private static IBattleManager GetBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
        {
            // You are allowed to add, change and remove code here
            return new ExtendedBattleManager(creaturesFactory, logger);
        }

        private static ICreaturesFactory GetCreaturesFactory()
        {
            // You are allowed to add, change and remove code here
            return new ExtendedCreaturesFactory();
        }
    }
}
namespace TheSlum.GameEngine
{
    using System;

    using TheSlum.Characters;
    using TheSlum.Items;

    internal class ExtendedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character;
            var id = inputParams[2];
            var x = int.Parse(inputParams[3]);
            var y = int.Parse(inputParams[4]);
            var team = (Team)Enum.Parse(typeof(Team), inputParams[5]);
            var type = inputParams[1];

            switch (type)
            {
                case "mage":
                    character = new Mage(id, x, y, team);
                    break;
                case "warrior":
                    character = new Warrior(id, x, y, team);
                    break;
                case "healer":
                default:
                    character = new Healer(id, x, y, team);
                    break;
            }

            this.characterList.Add(character);
        }

        protected new void AddItem(string[] inputParams)
        {
            var characterId = inputParams[1];
            var character = this.characterList.Find(x => x.Id == characterId);

            var itemClass = inputParams[2];
            var itemId = inputParams[3];

            Item item;
            switch (itemClass)
            {
                case "axe":
                    item = new Axe(itemId);
                    break;
                case "shield":
                    item = new Shield(itemId);
                    break;
                case "pill":
                    item = new Pill(itemId);
                    break;
                case "injection":
                default:
                    item = new Injection(itemId);
                    break;
            }

            character.AddToInventory(item);
        }
    }
}
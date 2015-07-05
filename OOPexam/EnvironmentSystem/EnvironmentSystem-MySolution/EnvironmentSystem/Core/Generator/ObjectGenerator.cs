namespace EnvironmentSystem.Core.Generator
{
    using System;
    using System.Collections.Generic;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Objects;
    using EnvironmentSystem.Models.Objects.FallingStar;
    using EnvironmentSystem.Models.Objects.Snowflake;
    using EnvironmentSystem.Models.Objects.UnstableStar;

    public class ObjectGenerator : IObjectGenerator<EnvironmentObject>
    {
        private const int ObjectsCount = 10;

        private const int StaticStarCount = 20;

        private readonly Random randomGenerator;

        private readonly int worldHeight;

        private readonly int worldWidth;

        public ObjectGenerator(int worldWidth, int worldHeight)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            this.randomGenerator = new Random();
        }

        public IEnumerable<EnvironmentObject> SeedInitialObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            var x = 0;
            var y = 0;
            for (var i = 0; i < StaticStarCount; i++)
            {
                x = this.randomGenerator.Next(0, this.worldWidth);
                y = this.randomGenerator.Next(0, this.worldHeight / 3 * 2);
                generatedObjects.Add(new Star(x, y));
            }

            x = this.randomGenerator.Next(this.worldWidth / 3, this.worldWidth / 3 * 2);
            y = this.randomGenerator.Next(0, this.worldHeight / 4);
            var dirX = this.randomGenerator.Next(-1, 2);
            generatedObjects.Add(new FallingStar(x, y, new Point(dirX, 1)));

            x = this.randomGenerator.Next(this.worldWidth / 4, this.worldWidth / 4 * 3);
            y = this.randomGenerator.Next(0, this.worldHeight / 4);
            dirX = this.randomGenerator.Next(-1, 2);
            generatedObjects.Add(new UnstableStar(x, y, new Point(dirX, 1)));

            generatedObjects.Add(new Ground(0, 25, this.worldWidth, 2, '#'));

            return generatedObjects;
        }

        public IEnumerable<EnvironmentObject> GenerateNextObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (var i = 0; i < ObjectsCount; i++)
            {
                var generateFlag = this.randomGenerator.Next(0, 5);

                if (generateFlag == 1)
                {
                    var x = this.randomGenerator.Next(0, this.worldWidth);
                    var envObject = new Snowflake(x, 1, 1, 1, new Point(0, 1));

                    generatedObjects.Add(envObject);
                }
            }

            return generatedObjects;
        }
    }
}
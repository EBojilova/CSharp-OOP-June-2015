namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    internal class Star : EnvironmentObject
    {
        private const int StarImageUpdateFrequency = 0;

        private static readonly Random RandomGenerator = new Random();

        private static readonly char[] StarChars = { 'O', '@', '0' };

        private int updateCount;

        public Star(int x, int y)
            : base(x, y, 1, 1)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            var i = RandomGenerator.Next(0, StarChars.Length);
            var starChar = StarChars[i];
            return new[,] { { starChar } };
        }

        public override void Update()
        {
            if (this.updateCount == StarImageUpdateFrequency)
            {
                this.ImageProfile = this.GenerateImageProfile();
                this.updateCount = 0;
            }

            this.updateCount++;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
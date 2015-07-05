namespace EnvironmentSystem.Models.Objects.Snowflake
{
    using System.Collections.Generic;

    internal class Snow : EnvironmentObject
    {
        public Snow(int x, int y)
            : base(x, y, 1, 1)
        {
            this.ImageProfile = new[,] { { '.' } };
            this.CollisionGroup = CollisionGroup.Snow;
        }

        public override void Update()
        {
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
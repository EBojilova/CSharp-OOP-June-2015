namespace EnvironmentSystem.Models.Objects.FallingStar
{
    using System.Collections.Generic;

    internal class FallingStar : MovingObject
    {
        public FallingStar(int x, int y, Point direction)
            : base(x, y, 1, 1, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new[,] { { 'O' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Snow || hitObjectGroup==CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            var producedObjects = new List<StarTail>
                                      {
                                          new StarTail(
                                              this.Bounds.TopLeft.X - this.Direction.X, 
                                              this.Bounds.TopLeft.Y - this.Direction.Y)

                                          // new StarTail(
                                          // this.Bounds.TopLeft.X - this.Direction.X * 2,
                                          // this.Bounds.TopLeft.Y - this.Direction.Y * 2),
                                          // new StarTail(
                                          // this.Bounds.TopLeft.X - this.Direction.X * 3,
                                          // this.Bounds.TopLeft.Y - this.Direction.Y * 3)
                                      };
            return producedObjects;
        }
    }
}
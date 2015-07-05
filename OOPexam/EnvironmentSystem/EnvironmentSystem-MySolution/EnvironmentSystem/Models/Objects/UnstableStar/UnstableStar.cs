namespace EnvironmentSystem.Models.Objects.UnstableStar
{
    using System.Collections.Generic;

    using EnvironmentSystem.Models.Objects.FallingStar;

    internal class UnstableStar : FallingStar
    {
        private int lifeTime;

        public UnstableStar(int x, int y, Point direction, int lifeTime = 8)
            : base(x, y, direction)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == 0)
            {
                this.Exists = false;
            }
            else
            {
               base.Update(); 
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.Exists)
            {
                var producedObjects = new List<EnvironmentObject>();
                for (int x = this.Bounds.TopLeft.X - 2; x <= this.Bounds.TopLeft.X + 2; x++)
                {
                    for (int y = this.Bounds.TopLeft.Y - 2; y < this.Bounds.TopLeft.Y + 2; y++)
                    {
                        if (!(x == this.Bounds.TopLeft.X && y == this.Bounds.TopLeft.Y))
                        {
                            producedObjects.Add(new Explosion(x, y));
                        }
                    }
                }
                return producedObjects;
            }

            return base.ProduceObjects();
        }
    }
}
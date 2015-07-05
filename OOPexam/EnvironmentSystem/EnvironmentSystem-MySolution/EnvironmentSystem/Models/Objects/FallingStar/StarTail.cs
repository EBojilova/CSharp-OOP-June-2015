namespace EnvironmentSystem.Models.Objects.FallingStar
{
    using System.Collections.Generic;

    internal class StarTail : EnvironmentObject
    {
        private int lifeTime;

        public StarTail(int x, int y, int lifeTme = 3)
            : base(x, y, 1, 1)
        {
            this.lifeTime = lifeTme;
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new[,] { { '*' } };
        }

        public override void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == 0)
            {
                this.Exists = false;
            }
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
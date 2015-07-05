namespace EnvironmentSystem.Models.Objects
{
    using EnvironmentSystem.Models.Objects.FallingStar;

    internal class Explosion : StarTail
    {
        public Explosion(int x, int y, int lifeTme = 2)
            : base(x, y, lifeTme)
        {
            this.CollisionGroup = CollisionGroup.Explosion;
        }
    }
}
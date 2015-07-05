using System;

namespace CustomExceptions
{
    public class Tank
    {
        private const int ShellDamage = 40;

        public Tank(int health)
        {
            this.Health = health;
            this.Shells = 3;//broi snariadi
        }

        public int Health { get; set; }

        public int Shells { get; private set; }

        public void Shoot(Tank enemy)
        {
            if (this.Shells == 0)
            {
                throw new TankException("Not enough shells to shoot");
            }
            enemy.Health -= ShellDamage;
            this.Shells--;
            Console.WriteLine("Left enemy Health after the shoot: {0}, left shells: {1}", enemy.Health,this.Shells);
        }
    }
}

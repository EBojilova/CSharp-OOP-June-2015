namespace BoxingAndUnboxing
{
    // Very bad practice! Structures should
    // contain no logic, but only data!
    internal struct Point : IMovable
    {
        public int x;

        public int y;

        public void Move(int x, int y) // Parameters x and y hide fields Point.x and Point.y
        {
            this.x += x;
            this.y += y;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.x, this.y);
        }
    }
}
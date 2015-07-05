namespace PassingOutParameters
{
    using System;

    public class Rectangle
    {
        private readonly int height;

        private readonly int width;

        private readonly int x;

        private readonly int y;

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void GetLocationAndDimensions(out Point location, out Dimensions dimensions)
        {
            location = new Point(this.x, this.y);
            dimensions = new Dimensions(this.width, this.height);
        }

        private static void Main()
        {
            var rect = new Rectangle(5, 10, 12, 8);

            var location = new Point(0, 0);
            var dimensions = new Dimensions(1, 2);

            // Location and dimension are not pre-initialized!
            rect.GetLocationAndDimensions(out location, out dimensions);

            Console.WriteLine("({0}, {1}, {2}, {3})", location.x, location.y, dimensions.width, dimensions.height);
        }
    }
}
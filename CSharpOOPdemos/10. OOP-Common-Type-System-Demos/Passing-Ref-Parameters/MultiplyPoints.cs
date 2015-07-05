namespace PassingRefParameters
{
    public static class MultiplyPoint
    {
        public static void IncorrectMultiplyBy2(Point point)
        {
            point.x *= 2;
            point.y *= 2;
        }

        public static void MultiplyBy2(ref Point point) // kogato tipa ne e referenten zadaljitelno se pishe ref za da se promeni stoinosta mu v stacka
        {
            point.x *= 2;
            point.y *= 2;
        }
    }
}
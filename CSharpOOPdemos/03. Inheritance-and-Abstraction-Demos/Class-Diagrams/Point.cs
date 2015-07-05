public struct Point //struct-not reference type
{
    //Constructor
    public Point(int x, int y)
        : this()
    {
        this.X = x;
        this.Y = y;
    }
    //Property
    public int X { get; set; }
    //Property
    public int Y { get; set; }
}

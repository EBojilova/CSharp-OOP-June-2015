public class Rectangle : Shape, ISufraceCalculatable
{
    //Constructor
    public Rectangle(float width, float height, int x, int y)
        : base(new Point(x, y))
    {
        this.Width = width;
        this.Height = height;
    }
    //Property
    private float Width { get; set; }
    //Property
    private float Height { get; set; }
    //Method
    public float CalculateSurface()
    {
        return this.Width * this.Height;
    }
}

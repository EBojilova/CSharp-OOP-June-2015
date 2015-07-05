public class Square : Shape, ISufraceCalculatable
{
    //Constructor
    public Square(float size, int x, int y)
        : base(new Point(x, y))
    {
        this.Size = size;
    }
    //Property
    private float Size { get; set; }
    //Method
    public float CalculateSurface()
    {
        return this.Size * this.Size;
    }
}

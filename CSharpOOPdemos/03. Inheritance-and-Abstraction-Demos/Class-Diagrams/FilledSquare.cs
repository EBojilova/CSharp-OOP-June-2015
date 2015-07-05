public class FilledSquare : Square
{
    //Constructor
    public FilledSquare(float size, int x, int y, Color color)
        : base(size, x, y)
    {
        this.Color = color;
    }
    //Property
    private Color Color { get; set; }
}

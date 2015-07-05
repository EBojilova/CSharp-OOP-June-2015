public class FilledRectangle : Rectangle
{
    //Constructor
    public FilledRectangle(float width, float height, int x, int y, Color color)
        : base(width, height, x, y)
    {
        this.Color = color;
    }
    //Property
    private Color Color { get; set; }
}

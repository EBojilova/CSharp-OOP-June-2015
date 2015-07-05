public abstract class Shape
{
    //Constructor
    protected Shape(Point position)
    {
        this.Position = position;
    }
    //Property
    protected Point Position { get; set; }
}
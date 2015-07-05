public struct Rectangle : IShape, IMovable, IResizable
{
    private int x;
    private int y;
    private int width;
    private int height;
    //Constructor, bez Propertita
    public Rectangle(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    //Ot Interfacite
    public void SetPosition(int x, int y)//From IShape
    {
        this.x = x;
        this.y = y;
    }

    public double CalculateSurface()//From IShape
    {
        return this.width * this.height;
    }

    public void Move(int deltaX, int deltaY) // From IMovable 
    {
        this.x += deltaX;
        this.y += deltaY;
    }

    public void Resize(int weightX, int weightY) // IResizable 
    {
        this.width = this.width * weightX;
        this.height = this.height * weightY;
    }

    public void ResizeByX(int weightX) // From IResizable 
    {
        this.width = this.width * weightX;
    }

    public void ResizeByY(int weightY) // From IResizable 
    {
        this.height = this.height * weightY;
    }
}

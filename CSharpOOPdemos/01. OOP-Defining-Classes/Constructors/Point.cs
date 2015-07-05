public class Point
{
	//Fields
    private int xCoord;
	private int yCoord;
	private string name;
	
	//Constructor without parameters
    public Point() : this(0, 0) // Reuse the constructor with 2 parameters
	{ 
    }
    //Constructor with 2 parameters
	public Point(int xCoord, int yCoord)
	{
		this.xCoord = xCoord;
		this.yCoord = yCoord;
		this.name = string.Format(
			"Point({0},{1})", xCoord, yCoord);
	}
    //Property
	public int XCoord
	{
		get { return this.xCoord; }
		set { this.xCoord = value; }
	}
    //Property
	public int YCoord
	{
		get { return this.yCoord; }
		set { this.yCoord = value; }
	}
    //Propety
	public string Name
	{
		get { return this.name; }
		set { this.name = value; }
	}
} 

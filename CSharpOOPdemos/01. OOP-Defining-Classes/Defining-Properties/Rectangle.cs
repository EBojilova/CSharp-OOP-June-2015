using System;

class Rectangle
{
	//Fields
    private float height;
	private float width;

	//Constructor
    public Rectangle(float height, float width)
	{
		this.height = height;
		this.width = width;
	}

	//Property
    public float Height
	{
		get { return height; }
		set { height = value; }
	}
    //Property
	public float Width
	{
		get { return width; }
		set { width = value; }
	}
    //Property- READ ONLY-we can not set a value to it in the main- it can only be calculated
	public float Area
	{
		get
		{
			return height * width;
		}
	}
} 

using System;

public class Point
{
    //Fields
    private int xCoord;
    private int yCoord;
    //Constructor
    public Point(int xCoord, int yCoord)
    {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }
    //Method
    public double CalcDistance(Point p)
    {
        return Math.Sqrt(
          (p.xCoord - this.xCoord) * (p.xCoord - this.xCoord) +
          (p.yCoord - this.yCoord) * (p.yCoord - this.yCoord));
    }
}
public struct Color // struct-not reference type
{
    //Constructor
    public Color(byte redValue, byte greenValue, byte blueValue)
        : this()
    {
        this.RedValue = redValue;
        this.GreenValue = greenValue;
        this.BlueValue = blueValue;
    }
    //Properties
    public byte RedValue { get; set; }

    public byte GreenValue { get; set; }

    public byte BlueValue { get; set; }
}

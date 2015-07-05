using System;

using Structures;

public class StructuresExample // Structorite ne mogat da se naslediavat te sa sealed class(zabraneno e naslediavaneto im)
{
    private static void Main()
    {
        var c = new Color { RedValue = 1, GreenValue = 2, BlueValue = 3 };

        var square = new Square(
            new Point { X = 5, Y = -3 }, 
            7, 
            new Color { RedValue = 73, GreenValue = 158, BlueValue = 76 }, 
            new Color { RedValue = 0, GreenValue = 255, BlueValue = 133 }, 
            Edges.Rounded);
        Console.WriteLine(square);

        square.Edges = Edges.Straight;
        square.BorderColor = new Color { RedValue = 0, GreenValue = 0, BlueValue = 0 };

        // Note: this will not compile (Point is value-type)
        // square.Location.X = square.Location.X + 10;
        var location = square.Location; // pravim nova instancia i sled tova ia prisvoiavame
        location.X += 10;
        square.Location = location;

        Console.WriteLine(square);
    }
}
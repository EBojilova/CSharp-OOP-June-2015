using System;

internal delegate int StringDelegate<T>(T value); // jelatelno e delegata da e public- priema string i vrasta int

public class GenericDelegates
{
    private static int PrintString(string str) // statichen
    {
        Console.WriteLine("Str: {0}", str);
        return 1;
    }

    private int PrintStringLength(string value)
    {
        // ne statichen 
        Console.WriteLine("Length: {0}", value.Length);
        return 2;
    }

    public static void Main()
    {
        var del = new StringDelegate<string>(PrintString); // triabva da se ukaje v diamantentie skobi kakav ste bade parametara na Generic delegata
        var md = new GenericDelegates(); // instancia na tekustia klas(sazdavam obekt)
        del += md.PrintStringLength;
        var result = del("Pesho");
        Console.WriteLine(result); // ste otpechata 2- rezultata ot poslednia method, a otgore ste otpechata komandite ot vseki method
    }
}
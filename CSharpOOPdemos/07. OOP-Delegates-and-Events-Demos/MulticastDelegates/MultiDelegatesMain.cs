using System;

internal delegate int StringDelegate(string value); // jelatelno e delegata da e public- priema string i vrasta int

public class MultiDelegatesMain
{
    public static void Main()
    {
        var del = new StringDelegate(MultiDelegatesMain.PrintString); // statichen e i se izvikva direktno ot klasa v koito e

        var md = new MultiDelegatesMain(); // instancia na tekustia klas(sazdavam obekt)
        del += md.PrintStringLength;

        var result = del("Pesho");
        Console.WriteLine(result);

            // ste otpechata 2- rezultata ot poslednia method, a otgore ste otpechata komandite ot vseki method
    }

    private static int PrintString(string str)
    {
        // statichen
        Console.WriteLine("Str: {0}", str);
        return 1;
    }

    private int PrintStringLength(string value)
    {
        // ne statichen 
        Console.WriteLine("Length: {0}", value.Length);
        return 2;
    }
}
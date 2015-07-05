using System;

using Value_And_Reference_Types;

// Reference type
internal class RefClass
{
    public int Value { get; set; }
}

// Value type
internal struct ValStruct
{
    public int Value { get; set; }
}

internal class ValueAndReferenceTypes
{
    private static void Main(string[] args)
    {
        var refExample = new RefClass();
        refExample.Value = 100;
        var refExample2 = refExample;
        refExample2.Value = 200;
        Console.WriteLine(refExample.Value); // Prints 200

        var valExample = new ValStruct();
        valExample.Value = 100;
        var valExample2 = valExample;
        valExample2.Value = 200;
        Console.WriteLine(valExample.Value); // Prints 100
    }
}
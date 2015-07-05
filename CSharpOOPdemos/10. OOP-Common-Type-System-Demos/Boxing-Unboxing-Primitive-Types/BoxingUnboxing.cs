using System;

class BoxingUnboxing
{
    static void Main(string[] args)
    {
        int value1 = 1;
        object obj = value1; // boxing performed

        value1 = 12345; // only stack value is changed

        int value2 = (int)obj;  // unboxing performed
        Console.WriteLine(value2); // prints 1

        long value3 = (long)(int)obj; // unboxing, ok e taikato predi tova e bilo int i to se pobira v long
        long value4 = (long)obj; // InvalidCastException, ne e ok, tai kato predi tva e bilo int
    }
}
 
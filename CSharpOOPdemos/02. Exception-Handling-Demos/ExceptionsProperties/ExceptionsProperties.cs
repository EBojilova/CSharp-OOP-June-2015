using System;
using System.IO;

public class ExceptionsProperties
{
    public static void Main()
    {
        try
        {
            CauseFormatException();
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Exception caught: " + fe);//Otpechatvase s Error po sredata, t.e. e dobra praktika da se otpechata ne standartnia potok, a potoka za greshki Error
            Console.Error.WriteLine("\nMessage: " + fe.Message);
            Console.Error.WriteLine("\nStack Trace: " + fe.StackTrace);
            //Mnogo e polezno kato pisheme programa i po-kasno iskame da razgledame exeptionite da gi zapishem vav fail sas StreamWriter
        //    using (var sw = new StreamWriter("exeptionList.txt"))
        //    {
        //        sw.WriteLine("Exception caught: " + fe);
        //    }
        }
    }

    public static void CauseFormatException()
    {
        string str = "an invalid number";
        int.Parse(str);
    }
}

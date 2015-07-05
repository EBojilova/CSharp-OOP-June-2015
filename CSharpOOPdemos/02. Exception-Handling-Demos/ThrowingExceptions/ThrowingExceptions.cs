using System;

public class ThrowingExceptions
{
    public static void Main()
    {
        try
        {
            Sqrt(-1);
        }
        catch (ArgumentOutOfRangeException ex)// tai kato otnovo hvarliame greshkata otdolu s throw, greskata niama da se obraboti, a samo ste ia vidim i moje po-natatak po Stack trace niakoi da reshi da ia obraboti
        {
            Console.Error.WriteLine("Error: " + ex.Message);//prihvastame edin exeption(mojem da go zapishem niakade sas streamWriter) i tai kato ne mojem da go obrabotim go hvarliame otnovo na sledvastiat red
            throw;
        }
    }

    public static double Sqrt(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("Sqrt for negative numbers is undefined!");
        }
        return Math.Sqrt(value);
    }
}

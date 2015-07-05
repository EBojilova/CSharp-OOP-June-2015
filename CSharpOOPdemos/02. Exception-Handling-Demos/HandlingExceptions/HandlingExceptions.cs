using System;

public class HandlingExceptions
{
    public static void Main()
    {
        string str = Console.ReadLine();
        //kulturnia nachin da obrabotvame exeptioni. 
        try
        {
            int.Parse(str);
            Console.WriteLine("You entered a valid Int32 number {0}.", str);
        }
        catch (FormatException)
            //vliza se vav vzeki catch posledovateno v sluchai na exeptioni , ako exeptiona e nikoi ot izbroenite programata ste izgarmi
        {
            Console.WriteLine("Invalid integer number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too big to fit in Int32!");
        }
        //nai-nakraia se slagat po-obstite exeptioni- ako sa v nachaloto niama da se komilirat, poradi polimorfizma v OOP
        //catch (Exception)//tuka se vliza koito i exeption da vaznikne(nepreporachitelno, tai kato ima exeptioni koito ne e jelatelno da se obrabotvat-primerno Out of memory(svarshila RAM pamet))
        //{
        //Console.WriteLine("Something happened");// ne mojem da kajem tochno na usara kade e sbarkal, tai kato ne znaem vida na exeptiona
        //}
    }
}

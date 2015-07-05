using System;
// PO PRINCIP STATICHNITE NESTA TRIABVA MAX DA SE IZBIAGVAT
class SqrtPrecalculated// klas s niakolko statichni metoda(vkl Main) poleta i konstruktora
{
    public const int MaxValue = 10000;//konstantite sa promenlivi na koito ne mojem da promeniame stoinosta, te sa statichni i ne triabva da pishem static

    // Static field
    private static int[] sqrtValues;

    // Static constructor, s nego ne mogat da se praviat novi obekti, toi se izvikva samo kogato klasa za parvi pat bade zareden v pametta
    static SqrtPrecalculated()//statichnia konstruktor ne moje da priema parametri, pishe se samo ()
    {
        sqrtValues = new int[MaxValue + 1];
        for (int i = 0; i < sqrtValues.Length; i++)
        {
            sqrtValues[i] = (int)Math.Sqrt(i);
        }
        //Console.WriteLine("Constructor");// pokazvame, che parvonachalno se zaredja v pametta
    }

    // Static method 
    public static int GetSqrt(int value)
    {
       // Console.WriteLine("Method");// pokazvame, che se izpalniava samo methoda
        return sqrtValues[value];
    }

    // The Main() method is always static, zastoto e edin edinstven
    static void Main()
    {
        Console.WriteLine(SqrtPrecalculated.GetSqrt(254));//Ne se izvikva konstruktora na klasa a direktno metoda
    }
}

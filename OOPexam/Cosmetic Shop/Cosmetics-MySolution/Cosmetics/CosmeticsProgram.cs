namespace Cosmetics
{
    using System;
    using System.IO;

    using Cosmetics.Engine;

    public class CosmeticsProgram
    {
        public static void Main()
        {
            ////using (var writher = new StreamWriter(@"../../OUTPUT.txt", false))
            ////{
            ////    Console.SetOut(writher);
                CosmeticsEngine.Instance.Start();
            ////}
        }
    }
}
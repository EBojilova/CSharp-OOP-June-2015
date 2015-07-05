namespace ConsoleForum
{
    using System;
    using System.IO;

    using ConsoleForum.Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            //using (var writher = new StreamWriter(@"../../OUTPUT.txt",false))
            //{
            //    Console.SetOut(writher);
                IForum forum = new ExtendedForum();
                forum.Run();
            //}
        }
    }
}
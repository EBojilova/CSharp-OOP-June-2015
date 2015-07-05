namespace BookStore.UI
{
    using System;
    using System.IO;

    using BookStore.Interfaces;

    internal class FileRenderer : IRenderer
    {
        public void WriteLine(string message, params object[] parameters)
        {
            using (var writer = File.AppendText(@"../../OUTPUT.txt"))
            {
                writer.WriteLine(message, parameters);
            }
        }
    }
}
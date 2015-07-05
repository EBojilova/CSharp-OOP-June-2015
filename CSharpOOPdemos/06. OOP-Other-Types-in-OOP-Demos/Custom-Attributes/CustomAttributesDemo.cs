namespace _1.CustomAttributesDemo
{
    using System;

    [Author("Svetlin Nakov")]
    [Author("Bay Ivan")]
    internal class CustomAttributesDemo
    {
        private static void Main(string[] args)
        {
            var type = typeof(CustomAttributesDemo);
            var allAttributes = type.GetCustomAttributes(false);
            foreach (AuthorAttribute authorAttribute in allAttributes)
            {
                Console.WriteLine("This class is written by {0}. ", authorAttribute.Name);
            }
        }
    }
}
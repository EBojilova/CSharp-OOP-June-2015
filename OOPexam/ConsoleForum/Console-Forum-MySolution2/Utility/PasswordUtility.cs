namespace ConsoleForum.Utility
{
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordUtility
    {
        public static string Hash(string password)
        {
            var hasher = MD5.Create();

            return GetHash(hasher, password);
        }

        private static string GetHash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            foreach (var b in data)
            {
                sBuilder.Append(b.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
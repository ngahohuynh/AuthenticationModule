using System;
using System.Text;
using static System.Security.Cryptography.HashAlgorithm;

namespace DataAccess.Utils
{
    public static class StringUtils
    {
        private const string prefix = "B889TUPCZep4zeuL";

        public static string EncodePassword(this string password)
        {
            var bytes = Encoding.Unicode.GetBytes(prefix + password);
            var inArray = Create("SHA1").ComputeHash(bytes);

            return Convert.ToBase64String(inArray);
        }

        public static bool Verify(this string current, string encrypted)
        {
            return string.Equals(current.EncodePassword(), encrypted);
        }
    }
}

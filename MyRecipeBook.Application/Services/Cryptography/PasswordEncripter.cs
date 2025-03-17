using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Application.Services.Cryptography
{
    public class PasswordEncripter
    {
        public static string Encrypt(string password)
        {
            var newPassword = $"{password}{"ABC"}";
            var bytes = Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] hashBytes)
        {
            var builder = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                builder.Append(hashByte.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

using System;
using System.Text;

namespace TeduShopingOnline.Common.Helpers
{
    public class PasswordHelper
    {
        public static string GeneratePassword(int length)
        {
            const string passwordCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                stringBuilder.Append(passwordCharacters[random.Next(passwordCharacters.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}

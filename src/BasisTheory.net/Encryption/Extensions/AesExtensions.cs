using System.Security.Cryptography;
using BasisTheory.net.Common.Extensions;

namespace BasisTheory.net.Encryption.Extensions
{
    public static class AesExtensions
    {
        public static string ToAesString(this Aes aes)
        {
            return aes == null ? null : $"{aes.Key.ToBase64String()}.{aes.IV.ToBase64String()}";
        }

        public static Aes FromAesString(this string aesString)
        {
            var aesKey = Aes.Create();

            var aesParts = aesString.Split('.');
            aesKey.Key = aesParts[0].FromBase64String();
            aesKey.IV = aesParts[1].FromBase64String();

            return aesKey;
        }
    }
}

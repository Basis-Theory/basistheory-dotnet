using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Extensions;

namespace BasisTheory.net.Encryption
{
    public static class AesEncryptionService
    {
        public static async Task<string> EncryptAsync(Aes key, string plaintext)
        {
#if NETSTANDARD2_0
            using var msEncrypt = new MemoryStream();
            using (var cryptoStream = new CryptoStream(msEncrypt, key.CreateEncryptor(), CryptoStreamMode.Write)) {
                using (var streamWriter = new StreamWriter(cryptoStream))
#else
            await using var msEncrypt = new MemoryStream();
            await using (var cryptoStream = new CryptoStream(msEncrypt, key.CreateEncryptor(), CryptoStreamMode.Write)) {
                await using (var streamWriter = new StreamWriter(cryptoStream))
#endif
                {
                    await streamWriter.WriteAsync(plaintext);
                }
            }

            return msEncrypt.ToArray().ToBase64String();
        }

        public static async Task<string> DecryptAsync(Aes key, string ciphertext)
        {
#if NETSTANDARD2_0
            using var msDecrypt = new MemoryStream(ciphertext.FromBase64String());
            using var cryptoStream = new CryptoStream(msDecrypt, key.CreateDecryptor(), CryptoStreamMode.Read);
#else
            await using var msDecrypt = new MemoryStream(ciphertext.FromBase64String());
            await using var cryptoStream = new CryptoStream(msDecrypt, key.CreateDecryptor(), CryptoStreamMode.Read);
#endif
            using var streamReader = new StreamReader(cryptoStream);

            return await streamReader.ReadToEndAsync();
        }
    }
}

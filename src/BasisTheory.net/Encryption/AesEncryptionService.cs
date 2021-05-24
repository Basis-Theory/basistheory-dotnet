using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BasisTheory.net.Common.Extensions;

namespace BasisTheory.net.Encryption
{
    public static class AesEncryptionService
    {
        public static async Task<string> Encrypt(Aes key, string plaintext)
        {
            await using var msEncrypt = new MemoryStream();
            await using (var cryptoStream = new CryptoStream(msEncrypt, key.CreateEncryptor(), CryptoStreamMode.Write)) {
                await using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    await streamWriter.WriteAsync(plaintext);
                }
            }

            return msEncrypt.ToArray().ToBase64String();
        }

        public static async Task<string> Decrypt(Aes key, string ciphertext)
        {
            await using var msDecrypt = new MemoryStream(ciphertext.FromBase64String());
            await using var cryptoStream = new CryptoStream(msDecrypt, key.CreateDecryptor(), CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);

            return await streamReader.ReadToEndAsync();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Encryption.Extensions;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Encryption
{
    public interface IEncryptionService
    {
        Task<EncryptedData> Encrypt(string plaintext, ProviderEncryptionKey key);
        Task<string> Decrypt(EncryptedData data, ProviderEncryptionKey key);
    }

    public class EncryptionService : IEncryptionService
    {
        private readonly Dictionary<string, Dictionary<string, IEncryptionFactory>> _encryptionFactories;

        public EncryptionService(IEnumerable<IEncryptionFactory> encryptionFactories)
        {
            _encryptionFactories = encryptionFactories.GroupBy(x => x.Provider)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Algorithm, y => y));
        }

        public async Task<EncryptedData> Encrypt(string plaintext, ProviderEncryptionKey key)
        {
            string encryptedContent;
            string cekPlaintext;
            using (var aes = Aes.Create())
            {
                encryptedContent = await AesEncryptionService.Encrypt(aes, plaintext);
                cekPlaintext = aes.ToAesString();
            }

            var dataEncryption = _encryptionFactories[key.Provider][key.Algorithm];
            var encryptedCek = await dataEncryption.Encrypt(key.ProviderKeyId, cekPlaintext);

            return new EncryptedData
            {
                CipherText = encryptedContent,

                ContentEncryptionKey = new EncryptionKey
                {
                    Algorithm = EncryptionAlgorithm.AES.ToString(),
                    Key = encryptedCek
                },
                KeyEncryptionKey = new EncryptionKey
                {
                    Key = key.KeyId,
                    Algorithm = key.Algorithm
                }
            };
        }

        public async Task<string> Decrypt(EncryptedData data, ProviderEncryptionKey key)
        {
            var dataEncryption = _encryptionFactories[key.Provider][key.Algorithm];
            var cekPlaintext = await dataEncryption.Decrypt(key.ProviderKeyId, data.ContentEncryptionKey.Key);

            using var aes = cekPlaintext.FromAesString();
            return await AesEncryptionService.Decrypt(aes, data.CipherText);
        }
    }
}

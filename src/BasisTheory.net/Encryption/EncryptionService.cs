using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BasisTheory.net.Common.Extensions;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Encryption
{
    public interface IEncryptionService
    {
        Task<EncryptedDataResult> Encrypt(string plaintext, ProviderEncryptionKey key);
        Task<string> Decrypt(EncryptedDataResult data, ProviderEncryptionKey key);
    }

    public class EncryptionService : IEncryptionService
    {
        private readonly Dictionary<string, Dictionary<string, IEncryptionFactory>> _encryptionFactories;

        public EncryptionService(IEnumerable<IEncryptionFactory> encryptionFactories)
        {
            _encryptionFactories = encryptionFactories.GroupBy(x => x.Provider)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Algorithm, y => y));
        }

        public async Task<EncryptedDataResult> Encrypt(string plaintext, ProviderEncryptionKey key)
        {
            string encryptedContent;
            string cekPlaintext;
            using (var aes = Aes.Create())
            {
                encryptedContent = await AesEncryptionService.Encrypt(aes, plaintext);
                cekPlaintext = $"{aes.Key.ToBase64String()}.{aes.IV.ToBase64String()}";
            }

            var dataEncryption = _encryptionFactories[key.Provider][key.Algorithm];
            var encryptedCek = await dataEncryption.Encrypt(key.ProviderKeyId, cekPlaintext);

            return new EncryptedDataResult
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

        public async Task<string> Decrypt(EncryptedDataResult data, ProviderEncryptionKey key)
        {
            var dataEncryption = _encryptionFactories[key.Provider][key.Algorithm];
            var cekPlaintext = await dataEncryption.Decrypt(key.ProviderKeyId, data.ContentEncryptionKey.Key);

            var aes = Aes.Create();
            var aesParts = cekPlaintext.Split('.');
            aes.Key = aesParts[0].FromBase64String();
            aes.IV = aesParts[1].FromBase64String();

            return await AesEncryptionService.Decrypt(aes, data.CipherText);
        }
    }
}

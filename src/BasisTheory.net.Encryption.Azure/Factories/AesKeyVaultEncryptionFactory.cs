using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Encryption.Extensions;
using LazyCache;

namespace BasisTheory.net.Encryption.Azure.Factories
{
    public class AesKeyVaultEncryptionFactory : IEncryptionFactory
    {
        private readonly IAppCache _cache;
        private readonly TokenCredential _tokenCredential;

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.AES.ToString();

        public AesKeyVaultEncryptionFactory(IAppCache cache, TokenCredential tokenCredential)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
        }

        public async Task<string> Encrypt(string providerKeyId, string plaintext)
        {
            var key = await GetKey(providerKeyId);

            using var aes = key.FromAesString();

            var ciphertext = await AesEncryptionService.Encrypt(aes, plaintext);

            return ciphertext;
        }

        public async Task<string> Decrypt(string providerKeyId, string ciphertext)
        {
            var key = await GetKey(providerKeyId);

            using var aes = key.FromAesString();
            return await AesEncryptionService.Decrypt(aes, ciphertext);
        }

        private async Task<string> GetKey(string providerKeyId)
        {
            var id = new ObjectId("secrets", providerKeyId);

            return await _cache.GetOrAddAsync(id.ToCacheKey(),
                async () => await GetKey(id), DateTimeOffset.UtcNow.AddHours(1));
        }

        private async Task<string> GetKey(ObjectId id)
        {
            var secretClient = new SecretClient(id.VaultUri, _tokenCredential);
            var response = await secretClient.GetSecretAsync(id.Name, id.Version);
            return response.Value?.Value;
        }
    }
}

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Encryption.Extensions;
using LazyCache;
using Newtonsoft.Json;

namespace BasisTheory.net.Encryption.Azure.Factories
{
    public class AesKeyVaultEncryptionFactory : IEncryptionFactory
    {
        private readonly IAppCache _cache;
        private readonly TokenCredential _tokenCredential;
        private readonly Lazy<IProviderKeyService> _providerKeyService;
        private readonly Lazy<IEncryptionService> _encryptionService;

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.AES.ToString();

        public AesKeyVaultEncryptionFactory(IAppCache cache, TokenCredential tokenCredential,
            Lazy<IProviderKeyService> providerKeyService, Lazy<IEncryptionService> encryptionService)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
            _providerKeyService = providerKeyService;
            _encryptionService = encryptionService;
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
            if (response.Value?.Value == null) return null;

            var data = JsonConvert.DeserializeObject<EncryptedDataResult>(response.Value.Value);
            if (data == null) return null;

            var providerEncryptionKey = await _providerKeyService.Value.GetKeyByKeyIdAsync(data.KeyEncryptionKey.Key);
            return await _encryptionService.Value.Decrypt(data, providerEncryptionKey);
        }
    }
}

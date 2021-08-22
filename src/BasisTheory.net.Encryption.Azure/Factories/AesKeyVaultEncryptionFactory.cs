using System;
using System.Threading;
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

        public async Task<string> EncryptAsync(string providerKeyId, string plaintext,
            CancellationToken cancellationToken = default)
        {
            var key = await GetKey(providerKeyId, cancellationToken);

            using var aes = key.FromAesString();

            var ciphertext = await AesEncryptionService.EncryptAsync(aes, plaintext);

            return ciphertext;
        }

        public async Task<string> DecryptAsync(string providerKeyId, string ciphertext,
            CancellationToken cancellationToken = default)
        {
            var key = await GetKey(providerKeyId, cancellationToken);

            using var aes = key.FromAesString();
            return await AesEncryptionService.DecryptAsync(aes, ciphertext);
        }

        private async Task<string> GetKey(string providerKeyId, CancellationToken cancellationToken)
        {
            var id = new ObjectId("secrets", providerKeyId);

            return await _cache.GetOrAddAsync(id.ToCacheKey(),
                async () => await GetKey(id, cancellationToken), DateTimeOffset.UtcNow.AddHours(1));
        }

        private async Task<string> GetKey(ObjectId id, CancellationToken cancellationToken)
        {
            var secretClient = new SecretClient(id.VaultUri, _tokenCredential);
            var response = await secretClient.GetSecretAsync(id.Name, id.Version, cancellationToken);
            if (response.Value?.Value == null) return null;

            var data = JsonConvert.DeserializeObject<EncryptedData>(response.Value.Value);
            if (data == null) return null;

            var providerEncryptionKey = await _providerKeyService.Value.GetKeyByKeyIdAsync(data.KeyEncryptionKey.Key,
                Provider, data.KeyEncryptionKey.Algorithm, cancellationToken);
            return await _encryptionService.Value.DecryptAsync(data, providerEncryptionKey, cancellationToken);
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Encryption.Extensions;
using LazyCache;
using Newtonsoft.Json;

namespace BasisTheory.net.Encryption.Azure.Factories
{
    public class AesKeyVaultProviderKeyFactory : IProviderKeyFactory
    {
        private readonly IAppCache _cache;
        private readonly TokenCredential _tokenCredential;
        private readonly KeyVaultProviderKeyOptions _options;
        private readonly Lazy<IProviderKeyService> _providerKeyService;
        private readonly Lazy<IEncryptionService> _encryptionService;
        private readonly Func<string, Task<ProviderEncryptionKey>> _getByById;
        private readonly Func<string, string, string, Task<ProviderEncryptionKey>> _getKeyByName;
        private readonly Func<ProviderEncryptionKey, Task<ProviderEncryptionKey>> _saveKey;

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.AES.ToString();

        public AesKeyVaultProviderKeyFactory(IAppCache cache, TokenCredential tokenCredential,
            KeyVaultProviderKeyOptions options, Lazy<IProviderKeyService> providerKeyService,
            Lazy<IEncryptionService> encryptionService)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
            _options = options;
            _providerKeyService = providerKeyService;
            _encryptionService = encryptionService;

            _getKeyByName = (name, provier, algorithm) => GetByNameAsync(name);
            _saveKey = providerKey =>
            {
                providerKey.KeyId = providerKey.ProviderKeyId;
                return Task.FromResult(providerKey);
            };
        }

        public AesKeyVaultProviderKeyFactory(IAppCache cache, TokenCredential tokenCredential,
            KeyVaultProviderKeyOptions options, Lazy<IProviderKeyService> providerKeyService,
            Lazy<IEncryptionService> encryptionService,
            Func<string, Task<ProviderEncryptionKey>> getByById,
            Func<string, string, string, Task<ProviderEncryptionKey>> getKeyByName,
            Func<ProviderEncryptionKey, Task<ProviderEncryptionKey>> saveKey)
            : this(cache, tokenCredential, options, providerKeyService, encryptionService)
        {
            _getByById = getByById;
            _getKeyByName = getKeyByName;
            _saveKey = saveKey;
        }

        public async Task<ProviderEncryptionKey> GetOrCreateAsync(string name)
        {
            var existing = await _getKeyByName(name, Provider, Algorithm);
            if (existing != null) return existing;

            var rsaKey = await _providerKeyService.Value.GetOrCreateAsync(name,
                Provider, EncryptionAlgorithm.RSA.ToString());

            using var aesKey = Aes.Create();
            var keyValue = aesKey.ToAesString();

            var encryptionKey = await _encryptionService.Value.Encrypt(keyValue, rsaKey);

            var secretClient = new SecretClient(_options.KeyVaultUri, _tokenCredential);

            var key = await secretClient.SetSecretAsync(new KeyVaultSecret(name, JsonConvert.SerializeObject(encryptionKey))
            {
                Properties =
                {
                    Enabled = true,
                    ExpiresOn = DateTimeOffset.UtcNow.AddDays(_options.KeyProviderExpirationInDays),
                    NotBefore = DateTimeOffset.UtcNow
                }
            });

            var expirationDate = key.Value.Properties.ExpiresOn ??
                                 throw new NullReferenceException(nameof(key.Value.Properties.ExpiresOn));

            _cache.Add(new ObjectId("secrets", key.Value.Id).ToCacheKey(), keyValue, expirationDate);

            var providerKey = new ProviderEncryptionKey
            {
                Name = name,
                Provider = Provider,
                ProviderKeyId = key.Value.Id.ToString(),
                Algorithm = Algorithm,
                ExpirationDate = expirationDate
            };

            return await _saveKey(providerKey);
        }

        public async Task<ProviderEncryptionKey> GetByKeyIdAsync(string keyId)
        {
            if (_getByById != null)
                return await _getByById(keyId);

            var id = new ObjectId("secrets", keyId);

            var secretClient = new SecretClient(_options.KeyVaultUri, _tokenCredential);
            var secret = await secretClient.GetSecretAsync(id.Name, id.Version);
            if (secret.Value == null)
                throw new NullReferenceException(nameof(secret.Value));

            return new ProviderEncryptionKey
            {
                KeyId = keyId,
                Name = id.Name,
                Provider = Provider,
                ProviderKeyId = secret.Value.Id.ToString(),
                Algorithm = Algorithm,
                ExpirationDate = secret.Value.Properties.ExpiresOn ??
                                 throw new NullReferenceException(nameof(secret.Value.Properties.ExpiresOn))
            };
        }

        private async Task<ProviderEncryptionKey> GetByNameAsync(string name)
        {
            var secretClient = new SecretClient(_options.KeyVaultUri, _tokenCredential);

            try
            {
                var secret = await secretClient.GetSecretAsync(name);
                if (secret.Value == null || secret.Value.Properties.ExpiresOn < DateTimeOffset.UtcNow)
                    return null;

                return new ProviderEncryptionKey
                {
                    Name = name,
                    Provider = Provider,
                    ProviderKeyId = secret.Value.Id.ToString(),
                    Algorithm = Algorithm,
                    ExpirationDate = secret.Value.Properties.ExpiresOn ??
                                     throw new NullReferenceException(nameof(secret.Value.Properties.ExpiresOn))
                };
            }
            catch (RequestFailedException)
            {
                return null;
            }
        }
    }
}

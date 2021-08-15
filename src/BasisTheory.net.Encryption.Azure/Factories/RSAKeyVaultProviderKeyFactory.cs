using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Security.KeyVault.Keys;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Azure.Extensions;
using BasisTheory.net.Encryption.Entities;
using LazyCache;

namespace BasisTheory.net.Encryption.Azure.Factories
{
    public class RSAKeyVaultProviderKeyFactory : IProviderKeyFactory
    {
        private readonly IAppCache _cache;
        private readonly TokenCredential _tokenCredential;
        private readonly KeyVaultProviderKeyOptions _options;
        private readonly Func<string, Task<ProviderEncryptionKey>> _getKeyByKeyId;
        private readonly Func<string, string, string, Task<ProviderEncryptionKey>> _getKeyByName;
        private readonly Func<ProviderEncryptionKey, Task<ProviderEncryptionKey>> _saveKey;

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.RSA.ToString();

        public RSAKeyVaultProviderKeyFactory(IAppCache cache, TokenCredential tokenCredential,
            KeyVaultProviderKeyOptions options)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
            _options = options;

            _getKeyByKeyId = options.GetKeyByKeyId;
            _getKeyByName = options.GetKeyByName ?? ((name, provier, algorithm) => GetByNameAsync(name));
            _saveKey = options.SaveKey ?? (providerKey =>
            {
                providerKey.KeyId = providerKey.ProviderKeyId;
                return Task.FromResult(providerKey);
            });
        }

        public async Task<ProviderEncryptionKey> GetOrCreateKeyAsync(string name)
        {
            var existing = await _getKeyByName(name, Provider, Algorithm);
            if (existing != null) return existing;

            var keyClient = new KeyClient(_options.KeyVaultUri, _tokenCredential);

            var key = await keyClient.CreateRsaKeyAsync(new CreateRsaKeyOptions(name)
            {
                Enabled = true,
                KeyOperations = { KeyOperation.Decrypt, KeyOperation.Encrypt },
                KeySize = _options.RsaKeySize,
                ExpiresOn = DateTimeOffset.UtcNow.AddDays(_options.KeyProviderExpirationInDays),
                NotBefore = DateTimeOffset.UtcNow
            });

            var expirationDate = key.Value.Properties.ExpiresOn ??
                                 throw new NullReferenceException(nameof(key.Value.Properties.ExpiresOn));

            _cache.Add(new ObjectId("keys", key.Value.Id).ToCacheKey(), key.Value.Key.ToRSAString(), expirationDate);

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

        public async Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId)
        {
            if (_getKeyByKeyId != null)
                return await _getKeyByKeyId(keyId);

            var id = new ObjectId("keys", keyId);

            var keyClient = new KeyClient(_options.KeyVaultUri, _tokenCredential);
            var key = await keyClient.GetKeyAsync(id.Name, id.Version);
            if (key.Value == null)
                throw new NullReferenceException(nameof(key.Value));

            return new ProviderEncryptionKey
            {
                KeyId = keyId,
                Name = id.Name,
                Provider = Provider,
                ProviderKeyId = key.Value.Id.ToString(),
                Algorithm = Algorithm,
                ExpirationDate = key.Value.Properties.ExpiresOn ??
                                 throw new NullReferenceException(nameof(key.Value.Properties.ExpiresOn))
            };
        }

        private async Task<ProviderEncryptionKey> GetByNameAsync(string name)
        {
            var keyClient = new KeyClient(_options.KeyVaultUri, _tokenCredential);

            try
            {
                var key = await keyClient.GetKeyAsync(name);
                if (key.Value == null || key.Value.Properties.ExpiresOn < DateTimeOffset.UtcNow)
                    return null;

                return new ProviderEncryptionKey
                {
                    Name = name,
                    Provider = Provider,
                    ProviderKeyId = key.Value.Id.ToString(),
                    Algorithm = Algorithm,
                    ExpirationDate = key.Value.Properties.ExpiresOn ??
                                     throw new NullReferenceException(nameof(key.Value.Properties.ExpiresOn))
                };
            }
            catch (RequestFailedException)
            {
                return null;
            }
        }
    }
}

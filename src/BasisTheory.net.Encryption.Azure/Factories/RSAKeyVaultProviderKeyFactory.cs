using System;
using System.Threading.Tasks;
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

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.RSA.ToString();

        public RSAKeyVaultProviderKeyFactory(IAppCache cache, TokenCredential tokenCredential,
            KeyVaultProviderKeyOptions options)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
            _options = options;
        }

        public async Task<ProviderEncryptionKey> Create(string name)
        {
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

            return new ProviderEncryptionKey
            {
                Name = name,
                Provider = Provider,
                ProviderKeyId = key.Value.Id.ToString(),
                Algorithm = Algorithm,
                ExpirationDate = expirationDate
            };
        }
    }
}

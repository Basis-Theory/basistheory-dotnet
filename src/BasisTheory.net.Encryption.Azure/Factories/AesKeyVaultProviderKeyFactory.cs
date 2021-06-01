using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Encryption.Extensions;
using LazyCache;

namespace BasisTheory.net.Encryption.Azure.Factories
{
    public class AesKeyVaultProviderKeyFactory : IProviderKeyFactory
    {
        private readonly IAppCache _cache;
        private readonly TokenCredential _tokenCredential;
        private readonly KeyVaultProviderKeyOptions _options;

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.AES.ToString();

        public AesKeyVaultProviderKeyFactory(IAppCache cache, TokenCredential tokenCredential,
            KeyVaultProviderKeyOptions options)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
            _options = options;
        }

        public async Task<ProviderEncryptionKey> Create(string name)
        {
            using var aesKey = Aes.Create();
            var keyValue = aesKey.ToAesString();

            var secretClient = new SecretClient(_options.KeyVaultUri, _tokenCredential);

            var key = await secretClient.SetSecretAsync(new KeyVaultSecret(name, keyValue)
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

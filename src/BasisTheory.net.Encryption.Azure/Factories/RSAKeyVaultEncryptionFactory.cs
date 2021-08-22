using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using BasisTheory.net.Common.Extensions;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Azure.Extensions;
using LazyCache;
using EncryptionAlgorithm = BasisTheory.net.Encryption.Entities.EncryptionAlgorithm;

namespace BasisTheory.net.Encryption.Azure.Factories
{
    public class RSAKeyVaultEncryptionFactory : IEncryptionFactory
    {
        private readonly IAppCache _cache;
        private readonly TokenCredential _tokenCredential;
        private const RSAEncryptionPaddingMode DefaultRsaEncryptionPadding = RSAEncryptionPaddingMode.Pkcs1;

        public string Provider => "AZURE";
        public string Algorithm => EncryptionAlgorithm.RSA.ToString();

        public RSAKeyVaultEncryptionFactory(IAppCache cache,
            TokenCredential tokenCredential)
        {
            _cache = cache;
            _tokenCredential = tokenCredential;
        }

        public async Task<string> EncryptAsync(string providerKeyId, string plaintext,
            CancellationToken cancellationToken = default)
        {
            var key = await GetKey(providerKeyId, cancellationToken);

            using var rsaKey = key.FromRSAString();

            var ciphertext = rsaKey.Encrypt(plaintext.ToBytes(), DefaultRsaEncryptionPadding.ToRSAEncryptionPadding());

            return ciphertext.ToBase64String();
        }

        public async Task<string> DecryptAsync(string providerKeyId, string ciphertext,
            CancellationToken cancellationToken = default)
        {
            var cryptoClient = new CryptographyClient(new Uri(providerKeyId), _tokenCredential);

            var cipherBytes = ciphertext.FromBase64String();
            var decryptResult = await cryptoClient.DecryptAsync(DefaultRsaEncryptionPadding.ToEncryptionAlgorithm(),
                cipherBytes, cancellationToken);

            return decryptResult.Plaintext.ToUTF8String();
        }

        private async Task<string> GetKey(string providerKeyId, CancellationToken cancellationToken)
        {
            var id = new ObjectId("keys", providerKeyId);

            return await _cache.GetOrAddAsync(id.ToCacheKey(),
                async () => await GetKey(id, cancellationToken), DateTimeOffset.UtcNow.AddHours(1));
        }

        private async Task<string> GetKey(ObjectId id, CancellationToken cancellationToken)
        {
            var keyClient = new KeyClient(id.VaultUri, _tokenCredential);
            var response = await keyClient.GetKeyAsync(id.Name, id.Version, cancellationToken);
            return response.Value.Key.ToRSAString();
        }
    }
}

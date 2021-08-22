using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Extensions;
using BasisTheory.net.Encryption;
using BasisTheory.net.Encryption.Entities;
using Bogus;
using Xunit;

namespace BasisTheory.net.Tests.Encryption
{
    public class EncryptionServiceTests
    {
        private readonly Faker _faker;
        private readonly IEncryptionService _encryptionService;

        public EncryptionServiceTests()
        {
            _faker = new Faker();
            _encryptionService = new EncryptionService(new[] { new StubEncryptionFactory() });
        }

        [Fact]
        public async Task ShouldEncryptAndDecrypt()
        {
            var expectedPlaintext = _faker.Lorem.Paragraphs();
            var providerKey = new ProviderEncryptionKey
            {
                Provider = "INMEMORY",
                Algorithm = "RSA",
                KeyId = Guid.NewGuid().ToString(),
                ProviderKeyId = Guid.NewGuid().ToString()
            };

            var encryptedData = await _encryptionService.EncryptAsync(expectedPlaintext, providerKey);
            Assert.NotNull(encryptedData.CipherText);
            Assert.NotEqual(expectedPlaintext, encryptedData.CipherText);
            Assert.Null(encryptedData.ContentEncryptionKey.Provider);
            Assert.Equal("AES", encryptedData.ContentEncryptionKey.Algorithm);
            Assert.NotNull(encryptedData.ContentEncryptionKey.Key);
            Assert.Equal("INMEMORY", encryptedData.KeyEncryptionKey.Provider);
            Assert.Equal("RSA", encryptedData.KeyEncryptionKey.Algorithm);
            Assert.Equal(providerKey.KeyId, encryptedData.KeyEncryptionKey.Key);

            var plaintext = await _encryptionService.DecryptAsync(encryptedData, providerKey);
            Assert.Equal(expectedPlaintext, plaintext);
        }

        private class StubEncryptionFactory : IEncryptionFactory
        {
            public string Provider => "INMEMORY";
            public string Algorithm => "RSA";

            private readonly RSA RSAKey = RSA.Create();

            public Task<string> EncryptAsync(string providerKeyId, string plaintext,
                CancellationToken cancellationToken = default)
            {
                return Task.FromResult(RSAKey.Encrypt(plaintext.ToBytes(), RSAEncryptionPadding.Pkcs1).ToBase64String());
            }

            public Task<string> DecryptAsync(string providerKeyId, string ciphertext,
                CancellationToken cancellationToken = default)
            {
                return Task.FromResult(RSAKey.Decrypt(ciphertext.FromBase64String(), RSAEncryptionPadding.Pkcs1).ToUTF8String());
            }
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Azure.Extensions;
using BasisTheory.net.Encryption.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure
{
    public class AzureKeyVaultEncryptionWithRepoTests : IClassFixture<AzureWithRepoWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly TokenCredential _tokenCredential;

        public AzureKeyVaultEncryptionWithRepoTests(AzureWithRepoWebApplicationFactory factory)
        {
            _tokenCredential = factory.Services.GetService<TokenCredential>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task ShouldPerformFullRSAEncryptionLifecycle()
        {
            var request = new EncryptRequest
            {
                KeyName = Guid.NewGuid().ToString(),
                Algorithm = "RSA",
                Plaintext = Guid.NewGuid().ToString()
            };

            var encryptResponse = await _client.PostAsJsonAsync("/encryption/azure/encrypt", request);
            Assert.Equal(HttpStatusCode.OK, encryptResponse.StatusCode);

            var encryptedData = await JsonSerializer.DeserializeAsync<EncryptedData>(await encryptResponse.Content.ReadAsStreamAsync());
            Assert.NotNull(encryptedData);

            Assert.NotNull(encryptedData.CipherText);
            Assert.Equal("AES", encryptedData.ContentEncryptionKey.Algorithm);
            Assert.NotNull(encryptedData.ContentEncryptionKey.Key);
            Assert.Equal("RSA", encryptedData.KeyEncryptionKey.Algorithm);
            Assert.NotNull(encryptedData.KeyEncryptionKey.Key);

            var id = new ObjectId("keys", encryptedData.KeyEncryptionKey.Key);
            var keyClient = new KeyClient(id.VaultUri, _tokenCredential);
            var keyClientResponse = await keyClient.GetKeyAsync(id.Name, id.Version);
            Assert.NotNull(keyClientResponse.Value.Key.ToRSAString());

            var decryptResponse = await _client.PostAsJsonAsync("/encryption/azure/decrypt", encryptedData);
            Assert.Equal(HttpStatusCode.OK, decryptResponse.StatusCode);

            var plaintext = await decryptResponse.Content.ReadAsStringAsync();
            Assert.Equal(request.Plaintext, plaintext);
        }

        [Fact]
        public async Task ShouldPerformFullAESEncryptionLifecycle()
        {
            var request = new EncryptRequest
            {
                KeyName = Guid.NewGuid().ToString(),
                Algorithm = "AES",
                Plaintext = Guid.NewGuid().ToString()
            };

            var encryptResponse = await _client.PostAsJsonAsync("/encryption/azure/encrypt", request);
            Assert.Equal(HttpStatusCode.OK, encryptResponse.StatusCode);

            var encryptedData = await JsonSerializer.DeserializeAsync<EncryptedData>(await encryptResponse.Content.ReadAsStreamAsync());
            Assert.NotNull(encryptedData);

            Assert.NotNull(encryptedData.CipherText);
            Assert.Equal("AES", encryptedData.ContentEncryptionKey.Algorithm);
            Assert.NotNull(encryptedData.ContentEncryptionKey.Key);
            Assert.Equal("AES", encryptedData.KeyEncryptionKey.Algorithm);
            Assert.NotNull(encryptedData.KeyEncryptionKey.Key);

            var secretId = new ObjectId("secrets", encryptedData.KeyEncryptionKey.Key);
            var secretClient = new SecretClient(secretId.VaultUri, _tokenCredential);
            var secretResponse = await secretClient.GetSecretAsync(secretId.Name, secretId.Version);
            Assert.NotNull(secretResponse.Value.Value);

            var encryptedRSAKey = JsonSerializer.Deserialize<EncryptedData>(secretResponse.Value.Value);
            Assert.NotNull(encryptedRSAKey);

            var keyId = new ObjectId("keys", encryptedRSAKey.KeyEncryptionKey.Key);
            var keyClient = new KeyClient(keyId.VaultUri, _tokenCredential);
            var keyClientResponse = await keyClient.GetKeyAsync(keyId.Name, keyId.Version);
            Assert.NotNull(keyClientResponse.Value.Key.ToRSAString());

            var decryptResponse = await _client.PostAsJsonAsync("/encryption/azure/decrypt", encryptedData);
            Assert.Equal(HttpStatusCode.OK, decryptResponse.StatusCode);

            var plaintext = await decryptResponse.Content.ReadAsStringAsync();
            Assert.Equal(request.Plaintext, plaintext);
        }
    }
}

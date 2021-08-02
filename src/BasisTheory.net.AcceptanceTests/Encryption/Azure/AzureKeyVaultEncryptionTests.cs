using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure
{
    public class AzureKeyVaultEncryptionTests : IClassFixture<AzureWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly AzureWebApplicationFactory _factory;

        public AzureKeyVaultEncryptionTests(
            AzureWebApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task ShouldPerformFullEncryptionLifecycleWithAzureKeyVault()
        {
            var response = await _client.GetAsync("/encryption/azure");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

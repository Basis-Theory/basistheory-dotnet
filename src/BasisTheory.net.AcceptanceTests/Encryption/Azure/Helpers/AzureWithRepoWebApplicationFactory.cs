using System;
using System.Reflection.Metadata.Ecma335;
using BasisTheory.net.AcceptanceTests.Encryption.Helpers;
using BasisTheory.net.Encryption.Azure.AspNetCore;
using BasisTheory.net.Encryption.Azure.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers
{
    public class AzureWithRepoWebApplicationFactory : BaseWebApplicationFactory
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<InMemoryProviderKeyRepository>()
                    .AddScoped(s =>
                    {
                        var repository = s.GetRequiredService<InMemoryProviderKeyRepository>();

                        return new KeyVaultProviderKeyOptions
                        {
                            KeyVaultUri = new Uri("https://localhost:10090/"),
                            GetKeyByKeyId = (keyId, _) => repository.GetKeyByKeyIdAsync(keyId),
                            GetKeyByName = (name, provider, algorithm, _) => repository.GetKeyByNameAsync(name, provider, algorithm),
                            SaveKey = (providerKey, _) => repository.SaveAsync(providerKey)
                        };
                    })
                    .AddBasisTheoryAzureEncryption(tokenCredential: new LocalTokenCredential());
            });
        }
    }
}

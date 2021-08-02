using System;
using BasisTheory.net.AcceptanceTests.Encryption.Helpers;
using BasisTheory.net.Encryption.Azure.AspNetCore;
using BasisTheory.net.Encryption.Azure.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers
{
    public class AzureWebApplicationFactory : BaseWebApplicationFactory
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(new KeyVaultProviderKeyOptions
                {
                    KeyProviderExpirationInDays = 30,
                    RsaKeySize = 2048,
                    KeyVaultUri = new Uri("https://localhost:10090/")
                });

                services.AddBasisTheoryAzureEncryption();
            });
        }
    }
}

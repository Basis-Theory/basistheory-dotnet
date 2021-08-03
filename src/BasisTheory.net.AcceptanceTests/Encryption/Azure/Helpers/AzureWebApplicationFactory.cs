using System;
using BasisTheory.net.AcceptanceTests.Encryption.Helpers;
using BasisTheory.net.Encryption.Azure.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers
{
    public class AzureWebApplicationFactory : BaseWebApplicationFactory
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddBasisTheoryAzureEncryption(options =>
                {
                    options.KeyVaultUri = new Uri("https://localhost:10090/");
                }, new LocalTokenCredential());
            });
        }
    }
}

using Azure.Core;
using Azure.Identity;
using BasisTheory.net.Encryption.Azure.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BasisTheory.net.Encryption.Azure.AspNetCore
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddBasisTheoryAzureEncryption(this IServiceCollection services,
            TokenCredential tokenCredential = null)
        {
            tokenCredential ??= new DefaultAzureCredential();
            services.TryAddSingleton(tokenCredential);

            services.AddLazyCache();

            services.TryAddScoped<IEncryptionFactory, AesKeyVaultEncryptionFactory>();
            services.TryAddScoped<IEncryptionFactory, RSAKeyVaultEncryptionFactory>();

            return services;
        }
    }
}

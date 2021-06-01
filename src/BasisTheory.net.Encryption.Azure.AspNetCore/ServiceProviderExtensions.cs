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

            services.AddScoped<IEncryptionFactory, AesKeyVaultEncryptionFactory>();
            services.AddScoped<IEncryptionFactory, RSAKeyVaultEncryptionFactory>();

            services.AddScoped<IProviderKeyFactory, AesKeyVaultProviderKeyFactory>();
            services.AddScoped<IProviderKeyFactory, RSAKeyVaultProviderKeyFactory>();

            return services;
        }
    }
}

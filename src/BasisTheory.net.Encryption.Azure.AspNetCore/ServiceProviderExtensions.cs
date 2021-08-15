using System;
using System.Linq;
using Azure.Core;
using Azure.Identity;
using BasisTheory.net.Encryption.Azure.Entities;
using BasisTheory.net.Encryption.Azure.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BasisTheory.net.Encryption.Azure.AspNetCore
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddBasisTheoryAzureEncryption(this IServiceCollection services,
            KeyVaultProviderKeyOptions options = null, TokenCredential tokenCredential = null)
        {
            if (options != null)
                services.AddSingleton(options);

            if (services.All(x => x.ServiceType != typeof(KeyVaultProviderKeyOptions)))
                throw new ArgumentException($"{typeof(KeyVaultProviderKeyOptions)} must be registered");

            tokenCredential ??= new DefaultAzureCredential();
            services.TryAddSingleton(tokenCredential);

            services.AddLazyCache();

            services.AddScoped<IEncryptionFactory, AesKeyVaultEncryptionFactory>();
            services.AddScoped<IEncryptionFactory, RSAKeyVaultEncryptionFactory>();

            services.AddScoped<IProviderKeyFactory, AesKeyVaultProviderKeyFactory>();
            services.AddScoped<IProviderKeyFactory, RSAKeyVaultProviderKeyFactory>();

            return services;
        }

        public static IServiceCollection AddBasisTheoryAzureEncryption(this IServiceCollection services,
            Action<KeyVaultProviderKeyOptions> configure, TokenCredential tokenCredential = null)
        {
            var options = new KeyVaultProviderKeyOptions();
            configure(options);

            return services.AddBasisTheoryAzureEncryption(options, tokenCredential);
        }
    }
}

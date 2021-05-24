using System;
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
            KeyVaultProviderKeyOptions options, TokenCredential tokenCredential = null)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (options.KeyVaultUri == null)
                throw new ArgumentNullException(nameof(options.KeyVaultUri));

            services.AddSingleton(options);

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

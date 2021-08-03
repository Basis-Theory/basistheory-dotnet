using System;
using System.Linq;
using BasisTheory.net.Encryption;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BasisTheory.net.AspNetCore
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddBasisTheoryEncryption(this IServiceCollection services)
        {
            if (services.All(x => x.ServiceType != typeof(IProviderKeyRespository)))
                throw new ArgumentException($"{typeof(IProviderKeyRespository)} must be registered");

            services.TryAddScoped<IEncryptionService, EncryptionService>();
            services.TryAddScoped<IProviderKeyService, ProviderKeyService>();

            services.TryAddScoped(provider => new Lazy<IEncryptionService>(provider.GetRequiredService<IEncryptionService>));
            services.TryAddScoped(provider => new Lazy<IProviderKeyService>(provider.GetRequiredService<IProviderKeyService>));

            return services;
        }
    }
}

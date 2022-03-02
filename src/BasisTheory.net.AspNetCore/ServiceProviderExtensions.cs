using System;
using System.Collections.Generic;
using System.Text.Json;
using BasisTheory.net.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BasisTheory.net.AspNetCore
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddBasisTheoryEncryption(
            this IServiceCollection services,
            IConfiguration btConfiguration = null
        )
        {
            // todo: simple hack to not need to touch AcceptanceTests and other integrations
            // this should probably not be null in a final version
            if (btConfiguration != null)
            {
                btKeys.Add("basistheory", btConfiguration["ApiKey"]);
            }

            services.AddLazyCache();

            services.TryAddScoped<IEncryptionService, EncryptionService>();
            services.TryAddScoped<IProviderKeyService, ProviderKeyService>();

            services.TryAddScoped(provider => new Lazy<IEncryptionService>(provider.GetRequiredService<IEncryptionService>));
            services.TryAddScoped(provider => new Lazy<IProviderKeyService>(provider.GetRequiredService<IProviderKeyService>));

            return services;
        }

        // cannot inject service providers into json converters, so this is a workaround
        // todo: support multiple keys?
        private readonly static Dictionary<string, string> btKeys = new Dictionary<string, string>();

        public static string? GetBTApiKey(this JsonSerializerOptions options)
            => btKeys.TryGetValue("basistheory", out var value) ? value : null;

        public static void SetBTApiKey(this JsonSerializerOptions options, string apiKey)
            => btKeys.Add("basistheory", apiKey);
    }
}

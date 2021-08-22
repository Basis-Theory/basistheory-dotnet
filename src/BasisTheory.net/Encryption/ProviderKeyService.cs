using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;
using LazyCache;

namespace BasisTheory.net.Encryption
{
    public interface IProviderKeyService
    {
        Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId, string provider, string algorithm,
            CancellationToken cancellationToken = default);
        Task<ProviderEncryptionKey> GetOrCreateKeyAsync(string keyName, string provider, string algorithm,
            CancellationToken cancellationToken = default);
    }

    public class ProviderKeyService : IProviderKeyService
    {
        private readonly IAppCache _cache;
        private readonly Dictionary<string, Dictionary<string, IProviderKeyFactory>> _providerKeyFactories;

        public ProviderKeyService(IAppCache cache, IEnumerable<IProviderKeyFactory> providerKeyFactories)
        {
            _cache = cache;
            _providerKeyFactories = providerKeyFactories.GroupBy(x => x.Provider)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Algorithm, y => y));
        }

        public async Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId, string provider, string algorithm,
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetOrAddAsync($"providerkeys_{keyId}",
                async () =>
                {
                    var providerKeyFactory = _providerKeyFactories[provider][algorithm];
                    return await providerKeyFactory.GetKeyByKeyIdAsync(keyId, cancellationToken);
                },
                DateTimeOffset.UtcNow.AddHours(1));
        }

        public async Task<ProviderEncryptionKey> GetOrCreateKeyAsync(string keyName, string provider, string algorithm,
            CancellationToken cancellationToken = default)
        {
            return await _cache.GetOrAddAsync($"providerkeys_{keyName}_{provider}_{algorithm}",
                async () =>
                {
                    var providerKeyFactory = _providerKeyFactories[provider][algorithm];
                    return await providerKeyFactory.GetOrCreateKeyAsync(keyName, cancellationToken);
                }, DateTimeOffset.UtcNow.AddHours(1));
        }
    }
}

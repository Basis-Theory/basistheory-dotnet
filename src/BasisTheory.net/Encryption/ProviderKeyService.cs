using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;
using LazyCache;

namespace BasisTheory.net.Encryption
{
    public interface IProviderKeyService
    {
        Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId);
        Task<ProviderEncryptionKey> GetOrCreateAsync(string keyName, string provider, string algorithm);
    }

    public class ProviderKeyService : IProviderKeyService
    {
        private readonly IAppCache _cache;
        private readonly IProviderKeyRespository _providerKeyRespository;
        private readonly Dictionary<string, Dictionary<string, IProviderKeyFactory>> _providerKeyFactories;

        public ProviderKeyService(IAppCache cache, IProviderKeyRespository providerKeyRespository,
            IEnumerable<IProviderKeyFactory> providerKeyFactories)
        {
            _cache = cache;
            _providerKeyRespository = providerKeyRespository;
            _providerKeyFactories = providerKeyFactories.GroupBy(x => x.Provider)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Algorithm, y => y));
        }

        public async Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId)
        {
            return await _cache.GetOrAddAsync($"providerkeys_{keyId}",
                async () => await _providerKeyRespository.GetKeyByKeyIdAsync(keyId),
                DateTimeOffset.UtcNow.AddHours(1));
        }

        public async Task<ProviderEncryptionKey> GetOrCreateAsync(string keyName, string provider, string algorithm)
        {
            return await _cache.GetOrAddAsync($"providerkeys_{keyName}_{provider}_{algorithm}",
                async () =>
                {
                    var providerEncryptionKey =
                        await _providerKeyRespository.GetKeyByNameAsync(keyName, provider, algorithm);
                    if (providerEncryptionKey != null)
                        return providerEncryptionKey;

                    var providerKeyFactory = _providerKeyFactories[provider][algorithm];
                    providerEncryptionKey = await providerKeyFactory.Create(keyName);

                    return await _providerKeyRespository.SaveAsync(providerEncryptionKey);
                }, DateTimeOffset.UtcNow.AddHours(1));
        }
    }
}

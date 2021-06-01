using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;

namespace BasisTheory.net.Encryption
{
    public interface IProviderKeyService
    {
        Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId);
        Task<ProviderEncryptionKey> GetOrCreateAsync(string keyName, string provider, string algorithm);
    }

    public class ProviderKeyService : IProviderKeyService
    {
        private readonly IProviderKeyRespository _providerKeyRespository;
        private readonly Dictionary<string, Dictionary<string, IProviderKeyFactory>> _providerKeyFactories;

        public ProviderKeyService(IProviderKeyRespository providerKeyRespository,
            IEnumerable<IProviderKeyFactory> providerKeyFactories)
        {
            _providerKeyRespository = providerKeyRespository;
            _providerKeyFactories = providerKeyFactories.GroupBy(x => x.Provider)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Algorithm, y => y));
        }

        public Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId)
        {
            return _providerKeyRespository.GetKeyByKeyIdAsync(keyId);
        }

        public async Task<ProviderEncryptionKey> GetOrCreateAsync(string keyName, string provider, string algorithm)
        {
            var providerEncryptionKey = await _providerKeyRespository.GetKeyByNameAsync(keyName, provider, algorithm);
            if (providerEncryptionKey != null)
                return providerEncryptionKey;

            var providerKeyFactory = _providerKeyFactories[provider][algorithm];
            providerEncryptionKey = await providerKeyFactory.Create(keyName);

            return await _providerKeyRespository.SaveAsync(providerEncryptionKey);
        }
    }
}

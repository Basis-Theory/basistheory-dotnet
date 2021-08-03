using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using BasisTheory.net.Encryption;
using BasisTheory.net.Encryption.Entities;

namespace BasisTheory.net.AcceptanceTests.Encryption.Helpers
{
    public class InMemoryProviderKeyRespository : IProviderKeyRespository
    {
        private readonly ConcurrentBag<ProviderEncryptionKey> EncryptionKeys = new ConcurrentBag<ProviderEncryptionKey>();

        public Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId)
        {
            var providerEncryptionKey = EncryptionKeys.FirstOrDefault(x => x.KeyId == keyId);

            return Task.FromResult(providerEncryptionKey);
        }

        public Task<ProviderEncryptionKey> GetKeyByNameAsync(string name, string provider, string algorithm)
        {
            var providerEncryptionKey = EncryptionKeys.FirstOrDefault(x => x.Name == name && x.Provider == provider && x.Algorithm == algorithm);

            return Task.FromResult(providerEncryptionKey);
        }

        public Task<ProviderEncryptionKey> SaveAsync(ProviderEncryptionKey providerEncryptionKey)
        {
            providerEncryptionKey.KeyId = providerEncryptionKey.ProviderKeyId;
            EncryptionKeys.Add(providerEncryptionKey);

            return Task.FromResult(providerEncryptionKey);
        }
    }
}

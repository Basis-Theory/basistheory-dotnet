using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;

namespace BasisTheory.net.Encryption
{
    public interface IProviderKeyFactory
    {
        string Provider { get; }
        string Algorithm { get; }

        Task<ProviderEncryptionKey> GetOrCreateKeyAsync(string name);
        Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId);
    }
}

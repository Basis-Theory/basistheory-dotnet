using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;

namespace BasisTheory.net.Encryption
{
    public interface IProviderKeyRespository
    {
        Task<ProviderEncryptionKey> GetKeyByKeyIdAsync(string keyId);
        Task<ProviderEncryptionKey> GetKeyByNameAsync(string name, string provider, string algorithm);
        Task<ProviderEncryptionKey> SaveAsync(ProviderEncryptionKey providerEncryptionKey);
    }
}

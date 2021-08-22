using System.Threading;
using System.Threading.Tasks;

namespace BasisTheory.net.Encryption
{
    public interface IEncryptionFactory
    {
        string Provider { get; }
        string Algorithm { get; }

        Task<string> EncryptAsync(string providerKeyId, string plaintext,
            CancellationToken cancellationToken = default);
        Task<string> DecryptAsync(string providerKeyId, string ciphertext,
            CancellationToken cancellationToken = default);
    }
}

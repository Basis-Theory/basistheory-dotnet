using System.Threading.Tasks;

namespace BasisTheory.net.Encryption
{
    public interface IEncryptionFactory
    {
        string Provider { get; }
        string Algorithm { get; }

        Task<string> Encrypt(string providerKeyId, string plaintext);
        Task<string> Decrypt(string providerKeyId, string ciphertext);
    }
}

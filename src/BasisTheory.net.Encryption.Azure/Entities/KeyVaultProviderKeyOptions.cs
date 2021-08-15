using System;
using System.Threading.Tasks;
using BasisTheory.net.Encryption.Entities;

namespace BasisTheory.net.Encryption.Azure.Entities
{
    public sealed class KeyVaultProviderKeyOptions
    {
        public Uri KeyVaultUri { get; set; }
        public int RsaKeySize { get; set; } = 2048;
        public int KeyProviderExpirationInDays { get; set; } = 90;

        public Func<string, Task<ProviderEncryptionKey>> GetKeyByKeyId { get; set; }
        public Func<string, string, string, Task<ProviderEncryptionKey>> GetKeyByName { get; set; }
        public Func<ProviderEncryptionKey, Task<ProviderEncryptionKey>> SaveKey { get; set; }
    }
}

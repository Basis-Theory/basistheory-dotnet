using System;

namespace BasisTheory.net.Encryption.Azure.Entities
{
    public sealed class KeyVaultProviderKeyOptions
    {
        public Uri KeyVaultUri { get; set; }
        public int RsaKeySize { get; set; } = 2048;
        public int KeyProviderExpirationInDays { get; set; } = 90;
    }
}

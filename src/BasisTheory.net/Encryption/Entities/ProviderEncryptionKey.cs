using System;

namespace BasisTheory.net.Encryption.Entities
{
    public class ProviderEncryptionKey
    {
        public string KeyId { get; set; }
        public string Name { get; set; }

        public string Provider { get; set; }
        public string ProviderKeyId { get; set; }

        public string Algorithm { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }
    }
}

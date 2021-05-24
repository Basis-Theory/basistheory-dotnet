using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Encryption.Entities
{
    public class EncryptedDataResult
    {
        public string CipherText { get; set; }
        public EncryptionKey ContentEncryptionKey { get; set; }
        public EncryptionKey KeyEncryptionKey { get; set; }
    }
}

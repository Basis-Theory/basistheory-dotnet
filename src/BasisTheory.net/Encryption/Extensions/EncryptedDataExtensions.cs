using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Encryption.Extensions
{
    public static class EncryptedDataExtensions
    {
        public static EncryptionMetadata ToEncryptionMetadata(this EncryptedData encryptedData)
        {
            if (encryptedData == null) return null;

            return new EncryptionMetadata
            {
                ContentEncryptionKey = encryptedData.ContentEncryptionKey,
                KeyEncryptionKey = encryptedData.KeyEncryptionKey
            };
        }
    }
}

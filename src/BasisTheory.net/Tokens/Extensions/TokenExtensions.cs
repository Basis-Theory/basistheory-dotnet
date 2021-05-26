using System;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Tokens.Extensions
{
    public static class TokenExtensions
    {
        public static EncryptedDataResult ToEncryptedData(this Token token)
        {
            if (token == null) return null;

            return new EncryptedDataResult
            {
                CipherText = Convert.ToString(token.Data),
                ContentEncryptionKey = token.Encryption?.ContentEncryptionKey,
                KeyEncryptionKey = token.Encryption?.KeyEncryptionKey
            };
        }
    }
}

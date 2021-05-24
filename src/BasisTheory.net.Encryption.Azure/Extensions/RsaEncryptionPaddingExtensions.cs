using System;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace BasisTheory.net.Encryption.Azure.Extensions
{
    public static class RsaEncryptionPaddingExtensions
    {
        public static RSAEncryptionPadding ToRSAEncryptionPadding(this RSAEncryptionPaddingMode padding)
        {
            return padding switch
            {
                RSAEncryptionPaddingMode.Pkcs1 => RSAEncryptionPadding.Pkcs1,
                RSAEncryptionPaddingMode.Oaep => RSAEncryptionPadding.OaepSHA1,
                _ => throw new ArgumentOutOfRangeException(nameof(padding), padding, null)
            };
        }

        public static EncryptionAlgorithm ToEncryptionAlgorithm(this RSAEncryptionPaddingMode padding)
        {
            return padding switch
            {
                RSAEncryptionPaddingMode.Pkcs1 => EncryptionAlgorithm.Rsa15,
                RSAEncryptionPaddingMode.Oaep => EncryptionAlgorithm.RsaOaep,
                _ => throw new ArgumentOutOfRangeException(nameof(padding), padding, null)
            };
        }
    }
}

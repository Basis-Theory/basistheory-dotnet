using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys;
using BasisTheory.net.Common.Extensions;

namespace BasisTheory.net.Encryption.Azure.Extensions
{
    public static class RSAExtensions
    {
        public static string ToRSAString(this JsonWebKey jsonWebKey)
        {
            return jsonWebKey == null ?
                null :
                $"{jsonWebKey.E.ToBase64String()}.{jsonWebKey.N.ToBase64String()}";
        }

        public static RSA FromRSAString(this string rsaString)
        {
            var rsaParts = rsaString.Split(".");
            var rsaParameters = new RSAParameters
            {
                Exponent = rsaParts[0].FromBase64String(),
                Modulus = rsaParts[1].FromBase64String()
            };

            return RSA.Create(rsaParameters);
        }
    }
}

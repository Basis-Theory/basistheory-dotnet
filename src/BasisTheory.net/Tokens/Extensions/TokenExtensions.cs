using System;
using BasisTheory.net.Encryption.Entities;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json.Linq;

namespace BasisTheory.net.Tokens.Extensions
{
    public static class TokenExtensions
    {
        public static EncryptedData ToEncryptedData(this Token token)
        {
            if (token == null) return null;

            return new EncryptedData
            {
                CipherText = Convert.ToString(token.Data),
                ContentEncryptionKey = token.Encryption?.ContentEncryptionKey,
                KeyEncryptionKey = token.Encryption?.KeyEncryptionKey
            };
        }

        public static T ToDataType<T>(this Token token) where T : class
        {
            return token == null ? default : (T) ConvertDynamicToObject<T>(token.Data);
        }

        public static T ToMetadataType<T>(this Token token) where T : class
        {
            return token == null ? default : ConvertDynamicToObject<T>(token.Metadata);
        }

        private static T ConvertDynamicToObject<T>(dynamic data) where T : class
        {
            if (data is JObject jObjectData)
                return jObjectData.ToObject<T>();

            return data as T;
        }
    }
}

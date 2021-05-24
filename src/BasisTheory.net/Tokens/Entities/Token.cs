using System.Collections.Generic;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Encryption.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class Token : Response
    {
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        [JsonProperty("encryption")]
        public EncryptionData Encryption { get; set; }

        [JsonProperty("children")]
        public List<Token> Children { get; set; }

        public Token() {}

        public Token(EncryptedDataResult encryptedData)
        {
            if (encryptedData == null) return;

            Data = encryptedData.CipherText;
            Encryption = new EncryptionData
            {
                ContentEncryptionKey = encryptedData.ContentEncryptionKey,
                KeyEncryptionKey = encryptedData.KeyEncryptionKey
            };
        }
    }
}

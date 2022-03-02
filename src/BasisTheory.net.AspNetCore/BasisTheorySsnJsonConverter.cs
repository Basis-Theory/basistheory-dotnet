using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BasisTheory.net.Common.Constants;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Tokens;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.AspNetCore
{
    public class BasisTheorySsnJsonConverter : JsonConverter<string>
    {
        public override string Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var apiKey = options.GetBTApiKey();

            var value = reader.GetString();

            var client = new TokenClient(apiKey);
            var token = client.Create(new Token {
                Type = "social_security_number", // todo: support multiple types
                Data = value,
                Privacy = new DataPrivacy {
                    ImpactLevel = DataImpactLevel.HIGH
                },
                Metadata = new Dictionary<string, string> {
                    { "zeroCodeTest",  "Yep, it seems to be working" }
                }
            });

            return token.Id.ToString();
        }

        public override void Write(
            Utf8JsonWriter writer,
            string value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Utilities;
using BasisTheory.net.Tokens.Constants;
using BasisTheory.net.Tokens.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Tokens.Helpers
{
    public static class TokenFactory
    {
        public static readonly Faker<Token> TokenFaker = new Faker<Token>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Type, _ => TokenTypes.Token)
            .RuleFor(a => a.Data, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (_, _) => DateTimeOffset.UtcNow)
            .RuleFor(a => a.Encryption, (_, _) => EncryptionDataModelFaker.Generate())
            .RuleFor(t => t.Metadata, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<EncryptionKey> EncryptionKeyModelFaker = new Faker<EncryptionKey>()
            .RuleFor(a => a.Algorithm, (f, _) => f.PickRandom("AES", "RSA"))
            .RuleFor(a => a.Key, (f, _) => f.Random.Word());

        public static readonly Faker<EncryptionData> EncryptionDataModelFaker = new Faker<EncryptionData>()
            .RuleFor(a => a.ContentEncryptionKey, (_, _) => EncryptionKeyModelFaker.Generate())
            .RuleFor(a => a.KeyEncryptionKey, (_, _) => EncryptionKeyModelFaker.Generate());

        public static Token Token(Action<Token> applyOverrides = null)
        {
            var token = TokenFaker.Generate();

            applyOverrides?.Invoke(token);

            return token;
        }
    }
}
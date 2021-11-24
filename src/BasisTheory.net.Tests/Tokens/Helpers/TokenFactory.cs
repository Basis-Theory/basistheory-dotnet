using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Responses;
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
            .RuleFor(a => a.Fingerprint, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.Encryption, (_, _) => EncryptionMetadataModelFaker.Generate())
            .RuleFor(t => t.Metadata, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<EncryptionKey> EncryptionKeyModelFaker = new Faker<EncryptionKey>()
            .RuleFor(a => a.Algorithm, (f, _) => f.PickRandom("AES", "RSA"))
            .RuleFor(a => a.Key, (f, _) => f.Random.Word());

        public static readonly Faker<EncryptionMetadata> EncryptionMetadataModelFaker = new Faker<EncryptionMetadata>()
            .RuleFor(a => a.ContentEncryptionKey, (_, _) => EncryptionKeyModelFaker.Generate())
            .RuleFor(a => a.KeyEncryptionKey, (_, _) => EncryptionKeyModelFaker.Generate());

        public static readonly Faker<PaginatedList<Token>> PaginatedListFaker = new Faker<PaginatedList<Token>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => TokenFaker.Generate()).ToList());

        public static Token Token(Action<Token> applyOverrides = null)
        {
            var token = TokenFaker.Generate();

            applyOverrides?.Invoke(token);

            return token;
        }

        public static PaginatedList<Token> PaginatedTokens(Action<PaginatedList<Token>> applyOverrides = null)
        {
            var list = PaginatedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

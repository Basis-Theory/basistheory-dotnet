using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Constants;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Common.Utilities;
using BasisTheory.net.Tokens.Constants;
using BasisTheory.net.Tokens.Entities;
using BasisTheory.net.Tokens.Requests;
using Bogus;

namespace BasisTheory.net.Tests.Tokens.Helpers;

public static class TokenFactory
{
    public static readonly Faker<Token> TokenFaker = new Faker<Token>()
        .RuleFor(t => t.Id, (_, _) => Guid.NewGuid().ToString())
        .RuleFor(t => t.TenantId, (_, _) => Guid.NewGuid())
        .RuleFor(t => t.Type, _ => TokenTypes.Token)
        .RuleFor(t => t.Data, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
        .RuleFor(t => t.Mask, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
        .RuleFor(t => t.Fingerprint, (f, _) => f.Lorem.Word())
        .RuleFor(t => t.FingerprintExpression, (f, _) => f.Lorem.Word())
        .RuleFor(t => t.CreatedBy, (_, _) => Guid.NewGuid())
        .RuleFor(t => t.CreatedDate, (f, _) => f.Date.PastOffset())
        .RuleFor(t => t.ModifiedBy, (_, _) => Guid.NewGuid())
        .RuleFor(t => t.ModifiedDate, (f, _) => f.Date.PastOffset())
        .RuleFor(t => t.Encryption, (_, _) => EncryptionMetadataModelFaker.Generate())
        .RuleFor(t => t.Metadata, (f, _) =>
            f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                .ToDictionary(x => x.Key, x => x.Value))
        .RuleFor(t => t.Privacy, _ => DataPrivacyFaker.Generate())
        .RuleFor(t => t.Containers, f => new List<string> { $"/{f.Lorem.Word()}/{f.Lorem.Word()}/" })
        .RuleFor(t => t.SearchIndexes, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Random.String2(10)))
        .RuleFor(t => t.ExpiresAt, _ => DateTimeOffset.Now.AddDays(1))
        .RuleFor(t => t.Enrichments, _ => TokenEnrichmentsFaker.Generate());

    public static readonly Faker<TokenCreateRequest> TokenCreateRequestFaker = new Faker<TokenCreateRequest>()
        .RuleFor(t => t.Id, _ => Guid.NewGuid().ToString())
        .RuleFor(t => t.Type, _ => TokenTypes.Token)
        .RuleFor(t => t.Data, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
        .RuleFor(t => t.Mask, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
        .RuleFor(t => t.FingerprintExpression, (f, _) => f.Lorem.Word())
        .RuleFor(t => t.Encryption, (_, _) => EncryptionMetadataModelFaker.Generate())
        .RuleFor(t => t.Metadata, (f, _) =>
            f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                .ToDictionary(x => x.Key, x => x.Value))
        .RuleFor(t => t.Privacy, _ => DataPrivacyFaker.Generate())
        .RuleFor(t => t.Containers, f => new List<string> {$"/{f.Lorem.Word()}/{f.Lorem.Word()}/"})
        .RuleFor(t => t.SearchIndexes, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Random.String2(10)))
        .RuleFor(t => t.DeduplicateToken, (f, _) => f.Random.Bool())
        .RuleFor(t => t.ExpiresAt, _ => DateTimeOffset.Now.AddDays(1));

    public static readonly Faker<TokenUpdateRequest> TokenUpdateRequestFaker = new Faker<TokenUpdateRequest>()
        .RuleFor(t => t.Data, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
        .RuleFor(t => t.Mask, (f, _) => JsonUtility.SerializeObject(f.Random.Word()))
        .RuleFor(t => t.FingerprintExpression, (f, _) => f.Lorem.Word())
        .RuleFor(t => t.Metadata, (f, _) =>
            f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                .ToDictionary(x => x.Key, x => x.Value))
        .RuleFor(t => t.Encryption, (_, _) => EncryptionMetadataModelFaker.Generate())
        .RuleFor(t => t.Privacy, _ => UpdateDataPrivacyFaker.Generate())
        .RuleFor(t => t.Container, f => $"/{f.Lorem.Word()}/{f.Lorem.Word()}/")
        .RuleFor(t => t.SearchIndexes, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Random.String2(10)))
        .RuleFor(t => t.DeduplicateToken, (f, _) => f.Random.Bool())
        .RuleFor(t => t.ExpiresAt, _ => DateTimeOffset.Now.AddDays(1));

    public static readonly Faker<EncryptionKey> EncryptionKeyModelFaker = new Faker<EncryptionKey>()
        .RuleFor(t => t.Algorithm, (f, _) => f.PickRandom("AES", "RSA"))
        .RuleFor(t => t.Key, (f, _) => f.Random.Word());

    public static readonly Faker<EncryptionMetadata> EncryptionMetadataModelFaker = new Faker<EncryptionMetadata>()
        .RuleFor(t => t.ContentEncryptionKey, (_, _) => EncryptionKeyModelFaker.Generate())
        .RuleFor(t => t.KeyEncryptionKey, (_, _) => EncryptionKeyModelFaker.Generate());

    public static readonly Faker<PaginatedList<Token>> PaginatedListFaker = new Faker<PaginatedList<Token>>()
        .RuleFor(t => t.Pagination, (f, _) => new Pagination
        {
            TotalItems = f.Random.Number(1, 10),
            TotalPages = f.Random.Number(1, 10),
            PageNumber = f.Random.Number(1, 10),
            PageSize = f.Random.Number(1, 10),
        })
        .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => TokenFaker.Generate()).ToList());

    public static readonly Faker<DataPrivacy> DataPrivacyFaker = new Faker<DataPrivacy>()
        .RuleFor(x => x.Classification,
            f => f.PickRandom(
                DataClassification.GENERAL,
                DataClassification.BANK,
                DataClassification.PCI,
                DataClassification.PII))
        .RuleFor(x => x.ImpactLevel,
            f => f.PickRandom(
                DataImpactLevel.LOW,
                DataImpactLevel.MODERATE,
                DataImpactLevel.HIGH))
        .RuleFor(x => x.RestrictionPolicy,
            f => f.PickRandom(
                DataRestrictionPolicy.MASK,
                DataRestrictionPolicy.REDACT));

    public static readonly Faker<PrivacyUpdateModel> UpdateDataPrivacyFaker = new Faker<PrivacyUpdateModel>()
        .RuleFor(x => x.ImpactLevel,
            f => f.PickRandom(
                DataImpactLevel.LOW,
                DataImpactLevel.MODERATE,
                DataImpactLevel.HIGH))
        .RuleFor(x => x.RestrictionPolicy,
            f => f.PickRandom(
                DataRestrictionPolicy.MASK,
                DataRestrictionPolicy.REDACT));

    public static readonly Faker<TokenEnrichments> TokenEnrichmentsFaker = new Faker<TokenEnrichments>()
        .RuleFor(t => t.BinDetails, (_, _) => BinDetailsFaker.Generate());

    public static readonly Faker<BinDetails> BinDetailsFaker = new Faker<BinDetails>()
        .RuleFor(r => r.Bank, (f, _) => new BinDetails.BinDetailsBank
        {
            Name = f.Company.CompanyName(),
            Phone = f.Phone.PhoneNumber(),
            Url = f.Internet.Url(),
            CleanName = f.Company.CompanyName()
        })
        .RuleFor(r => r.Country, (f, _) => new BinDetails.BinDetailsCountry
        {
            Name = f.Address.Country(),
            Alpha2 = f.Address.CountryCode(),
            Numeric = f.Random.Int(1, 999).ToString().PadLeft(3, '0')
        })
        .RuleFor(r => r.Product, (f, _) => new BinDetails.BinDetailsProduct
        {
            Name = Guid.NewGuid().ToString(),
            Code = f.PickRandom(null, "F", "G", "A")
        })
        .RuleFor(r => r.CardBrand, f => f.PickRandom("VISA", "MASTERCARD", "AMEX"))
        .RuleFor(r => r.Type, f => f.PickRandom("Credit", "Debit"))
        .RuleFor(r => r.Prepaid, f => f.Random.Bool())
        .RuleFor(r => r.Reloadable, f => f.Random.Bool())
        .RuleFor(r => r.PanOrToken, f => f.PickRandom("pan", "token"))
        .RuleFor(r => r.AccountUpdater, f => f.Random.Bool())
        .RuleFor(r => r.AccountLevelManagement, f => f.Random.Bool())
        .RuleFor(r => r.DomesticOnly, f => f.Random.Bool())
        .RuleFor(r => r.GamblingBlocked, f => f.Random.Bool())
        .RuleFor(r => r.Level2, f => f.Random.Bool())
        .RuleFor(r => r.Level3, f => f.Random.Bool())
        .RuleFor(r => r.IssuerCurrency, f => f.PickRandom(null, "USD", "EUR", "BRL"))
        .RuleFor(r => r.CardSegmentType, f => f.PickRandom(null, "Consumer", "Business", "Commercial"))
        .RuleFor(r => r.ComboCard, f => f.PickRandom(null, "Credit and Prepaid", "Credit and Debit"))
        .RuleFor(r => r.BinLength, f => f.PickRandom(6, 8))
        .RuleFor(r => r.Authentication, f => f.PickRandom(
            Array.Empty<object>(),
            new object[]
            {
                new
                {
                    sca_name = "EU PSD2 - SCA"
                }
            }))
        .RuleFor(r => r.Cost,
            f => f.PickRandom(
                Array.Empty<object>(),
                new object[]
                {
                    new
                    {
                        cap_fixed_amount = 0.21,
                        cap_advalorem_amount = 0.0005,
                        cap_type_qualifier_text = "US DURBIN REGULATION DEBIT VISA"
                    }
                }));

    public static Token Token(Action<Token> applyOverrides = null)
    {
        var token = TokenFaker.Generate();
        applyOverrides?.Invoke(token);
        return token;
    }

    public static TokenCreateRequest TokenCreateRequest(Action<TokenCreateRequest> applyOverrides = null)
    {
        var request = TokenCreateRequestFaker.Generate();
        applyOverrides?.Invoke(request);
        return request;
    }

    public static TokenUpdateRequest TokenUpdateRequest(Action<TokenUpdateRequest> applyOverrides = null)
    {
        var request = TokenUpdateRequestFaker.Generate();
        applyOverrides?.Invoke(request);
        return request;
    }

    public static PaginatedList<Token> PaginatedTokens(Action<PaginatedList<Token>> applyOverrides = null)
    {
        var list = PaginatedListFaker.Generate();
        applyOverrides?.Invoke(list);
        return list;
    }
}
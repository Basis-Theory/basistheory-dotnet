using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Atomic.Cards.Entities;
using BasisTheory.net.Atomic.Cards.Requests;
using BasisTheory.net.Common.Responses;
using Bogus;

namespace BasisTheory.net.Tests.Atomic.Cards.Helpers
{
    public static class AtomicCardFactory
    {
        public static readonly Faker<AtomicCard> AtomicCardFaker = new Faker<AtomicCard>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid().ToString())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Type, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.Card, (_, _) => CardFaker.Generate())
            .RuleFor(a => a.Fingerprint, (f, _) => f.Lorem.Word())
            .RuleFor(t => t.Metadata, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<Card> CardFaker = new Faker<Card>()
            .RuleFor(a => a.CardNumber, (f, _) => f.Finance.CreditCardNumber())
            .RuleFor(a => a.ExpirationMonth, (f, _) => f.Random.Int(1, 12))
            .RuleFor(a => a.ExpirationYear, (f, _) => f.Random.Int(1000, 9999))
            .RuleFor(a => a.CardVerificationCode, (f, _) => f.Finance.CreditCardCvv());

        public static readonly Faker<PaginatedList<AtomicCard>> PaginatedListFaker = new Faker<PaginatedList<AtomicCard>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10)
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => AtomicCardFaker.Generate()).ToList());

        public static AtomicCard AtomicCard(Action<AtomicCard> applyOverrides = null)
        {
            var atomicCard = AtomicCardFaker.Generate();

            applyOverrides?.Invoke(atomicCard);

            return atomicCard;
        }

        public static PaginatedList<AtomicCard> PaginatedCards(Action<PaginatedList<AtomicCard>> applyOverrides = null)
        {
            var list = PaginatedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }

        public static AtomicCardUpdateRequest UpdateAtomicCardRequest(Action<AtomicCardUpdateRequest> applyOverrides = null)
        {
            var request = new AtomicCardUpdateRequest
            {
                Card = CardFaker.Generate()
            };

            applyOverrides?.Invoke(request);

            return request;
        }
    }
}

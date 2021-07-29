using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Exchanges.Entities;
using BasisTheory.net.ExchangeTemplates.Entities;
using BasisTheory.net.Tests.ExchangeTemplates.Helpers;
using BasisTheory.net.Tokens.Constants;
using Bogus;

namespace BasisTheory.net.Tests.Exchanges.Helpers
{
    public static class ExchangeFactory
    {
        public static readonly Faker<Exchange> ExchangeFaker = new Faker<Exchange>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ExchangeTemplate, (_, _) => ExchangeTemplateFactory.ExchangeTemplate())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(t => t.Configuration, (f, model) =>
                model.ExchangeTemplate.Configuration.Select(x => KeyValuePair.Create(x.Name, f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<PaginatedList<Exchange>> PagintedListFaker = new Faker<PaginatedList<Exchange>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => ExchangeFaker.Generate()).ToList());

        public static Exchange Exchange(Action<Exchange> applyOverrides = null)
        {
            var exchange = ExchangeFaker.Generate();

            applyOverrides?.Invoke(exchange);

            return exchange;
        }

        public static PaginatedList<Exchange> PaginatedExchanges(Action<PaginatedList<Exchange>> applyOverrides = null)
        {
            var list = PagintedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

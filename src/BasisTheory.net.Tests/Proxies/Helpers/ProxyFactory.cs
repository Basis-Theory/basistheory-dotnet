using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Proxies.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Proxies.Helpers
{
    public static class ProxyFactory
    {
        public static readonly Faker<Proxy> ProxyFaker = new Faker<Proxy>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.DestinationUrl, (f, _) => f.Internet.Url())
            .RuleFor(a => a.RequestReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.RequireAuthentication, (f, _) => f.Random.Bool())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset());

        public static readonly Faker<PaginatedList<Proxy>> PaginatedListFaker = new Faker<PaginatedList<Proxy>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => ProxyFaker.Generate()).ToList());


        public static Proxy Proxy(Action<Proxy> applyOverrides = null)
        {
            var proxy = ProxyFaker.Generate();

            applyOverrides?.Invoke(proxy);

            return proxy;
        }

        public static PaginatedList<Proxy> PaginatedProxies(Action<PaginatedList<Proxy>> applyOverrides = null)
        {
            var list = PaginatedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

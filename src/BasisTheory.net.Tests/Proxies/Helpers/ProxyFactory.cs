using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Proxies.Entities;
using BasisTheory.net.Proxies.Requests;
using BasisTheory.net.Tests.Applications.Helpers;
using Bogus;

namespace BasisTheory.net.Tests.Proxies.Helpers
{
    public static class ProxyFactory
    {
        private const string AlphanumericUnderscoreChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

        public static readonly Faker<Proxy> ProxyFaker = new Faker<Proxy>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.DestinationUrl, (f, _) => f.Internet.Url())
            .RuleFor(a => a.RequestReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ResponseReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.RequestTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.ResponseTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.RequireAuthentication, (f, _) => f.Random.Bool())
            .RuleFor(a => a.ApplicationId, (_, _) => Guid.NewGuid())
            .RuleFor(t => t.Configuration, (f, _) => f.Make(f.Random.Int(1, 5), () =>
                    new KeyValuePair<string, string>(
                        f.Random.String2(10, 20, AlphanumericUnderscoreChars), f.Random.Word()))
                .ToDictionary(x => x.Key, x => x.Value))
            .RuleFor(a => a.ProxyHost, (f, _) => f.Internet.Url())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset());

        public static readonly Faker<ProxyCreateRequest> ProxyCreateRequestFaker = new Faker<ProxyCreateRequest>()
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.DestinationUrl, (f, _) => f.Internet.Url())
            .RuleFor(a => a.RequestReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ResponseReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.RequestTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.ResponseTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.RequireAuthentication, (f, _) => f.Random.Bool())
            .RuleFor(a => a.Application, (_, _) => ApplicationFactory.Application())
            .RuleFor(t => t.Configuration, (f, _) => f.Make(f.Random.Int(1, 5), () =>
                    new KeyValuePair<string, string>(
                        f.Random.String2(10, 20, AlphanumericUnderscoreChars), f.Random.Word()))
                .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<ProxyUpdateRequest> ProxyUpdateRequestFaker = new Faker<ProxyUpdateRequest>()
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.DestinationUrl, (f, _) => f.Internet.Url())
            .RuleFor(a => a.RequestReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ResponseReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.RequestTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.ResponseTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.RequireAuthentication, (f, _) => f.Random.Bool())
            .RuleFor(a => a.Application, (_, _) => ApplicationFactory.Application())
            .RuleFor(t => t.Configuration, (f, _) => f.Make(f.Random.Int(1, 5), () =>
                    new KeyValuePair<string, string>(
                        f.Random.String2(10, 20, AlphanumericUnderscoreChars), f.Random.Word()))
                .ToDictionary(x => x.Key, x => x.Value));
        
        public static readonly Faker<ProxyPatchRequest> ProxyPatchRequestFaker = new Faker<ProxyPatchRequest>()
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.DestinationUrl, (f, _) => f.Internet.Url())
            .RuleFor(a => a.RequestReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ResponseReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.RequestTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.ResponseTransform, (f, _) => new ProxyTransform
            {
                Code = f.Random.Word()
            })
            .RuleFor(a => a.RequireAuthentication, (f, _) => f.Random.Bool())
            .RuleFor(a => a.Application, (_, _) => ApplicationFactory.Application())
            .RuleFor(t => t.Configuration, (f, _) => f.Make(f.Random.Int(1, 5), () =>
                    new KeyValuePair<string, string>(
                        f.Random.String2(10, 20, AlphanumericUnderscoreChars), f.Random.Word()))
                .ToDictionary(x => x.Key, x => x.Value));

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

        public static ProxyCreateRequest ProxyCreateRequest(Action<ProxyCreateRequest> applyOverrides = null)
        {
            var request = ProxyCreateRequestFaker.Generate();

            applyOverrides?.Invoke(request);

            return request;
        }

        public static ProxyUpdateRequest ProxyUpdateRequest(Action<ProxyUpdateRequest> applyOverrides = null)
        {
            var request = ProxyUpdateRequestFaker.Generate();

            applyOverrides?.Invoke(request);

            return request;
        }
        
        public static ProxyPatchRequest ProxyPatchRequest(Action<ProxyPatchRequest> applyOverrides = null)
        {
            var request = ProxyPatchRequestFaker.Generate();

            applyOverrides?.Invoke(request);

            return request;
        }

        public static PaginatedList<Proxy> PaginatedProxies(Action<PaginatedList<Proxy>> applyOverrides = null)
        {
            var list = PaginatedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

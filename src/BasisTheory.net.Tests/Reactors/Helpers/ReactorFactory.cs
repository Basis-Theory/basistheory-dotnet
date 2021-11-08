using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.ReactorFormulas.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using Bogus;

namespace BasisTheory.net.Tests.Reactors.Helpers
{
    public static class ReactorFactory
    {
        public static readonly Faker<Reactor> ReactorFaker = new Faker<Reactor>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ReactorFormula, (_, _) => ReactorFormulaFactory.ReactorFormula())
            .RuleFor(a => a.CreatedBy, (f, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (f, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(t => t.Configuration, (f, model) =>
                model.ReactorFormula.Configuration.Select(x => KeyValuePair.Create(x.Name, f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<PaginatedList<Reactor>> PagintedListFaker = new Faker<PaginatedList<Reactor>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => ReactorFaker.Generate()).ToList());

        public static readonly Faker<ReactResponse> ReactResponseFaker = new Faker<ReactResponse>()
            .RuleFor(a => a.Tokens, (_, _) => TokenFactory.Token())
            .RuleFor(t => t.Raw, (_, _) => TokenFactory.Token());

        public static readonly Faker<ReactRequest> ReactRequestFaker = new Faker<ReactRequest>()
            .RuleFor(a => a.ReactorId, (_, _) => Guid.NewGuid())
            .RuleFor(t => t.RequestParameters, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => (object) x.Value));

        public static Reactor Reactor(Action<Reactor> applyOverrides = null)
        {
            var reactor = ReactorFaker.Generate();

            applyOverrides?.Invoke(reactor);

            return reactor;
        }

        public static PaginatedList<Reactor> PaginatedReactors(Action<PaginatedList<Reactor>> applyOverrides = null)
        {
            var list = PagintedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }

        public static ReactResponse ReactResponse(Action<ReactResponse> applyOverrides = null)
        {
            var response = ReactResponseFaker.Generate();

            applyOverrides?.Invoke(response);

            return response;
        }

        public static ReactRequest ReactRequest(Action<ReactRequest> applyOverrides = null)
        {
            var request = ReactRequestFaker.Generate();

            applyOverrides?.Invoke(request);

            return request;
        }
    }
}

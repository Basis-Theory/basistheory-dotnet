using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.ReactorFormulas.Entities;
using BasisTheory.net.Tokens.Constants;
using Bogus;

namespace BasisTheory.net.Tests.ReactorFormulas.Helpers
{
    public static class ReactorFormulaFactory
    {
        public static readonly Faker<ReactorFormula> ReactorFormulaFaker = new Faker<ReactorFormula>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Type, _ => TokenTypes.Token)
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.Description, (f, _) => f.Lorem.Sentence())
            .RuleFor(a => a.SourceTokenType, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.Icon, (f, _) => f.Random.Hash())
            .RuleFor(a => a.Code, (f, _) => f.Lorem.Paragraph())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(t => t.Configuration, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => ReactorFormulaConfigurationFaker.Generate()))
            .RuleFor(t => t.RequestParameters, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => ReactorFormulaRequestParameterFaker.Generate()));

        public static readonly Faker<ReactorFormulaConfiguration> ReactorFormulaConfigurationFaker =
            new Faker<ReactorFormulaConfiguration>()
                .RuleFor(a => a.Name, (f, _) => f.Random.String2(20))
                .RuleFor(a => a.Type, (f, _) => f.Lorem.Word());

        public static readonly Faker<ReactorFormulaRequestParameter> ReactorFormulaRequestParameterFaker =
            new Faker<ReactorFormulaRequestParameter>()
                .RuleFor(a => a.Name, (f, _) => f.Random.String2(20))
                .RuleFor(a => a.Description, (f, _) => f.Lorem.Sentence())
                .RuleFor(a => a.Type, (f, _) => f.Lorem.Word())
                .RuleFor(a => a.IsOptional, (f, _) => f.Random.Bool());

        public static readonly Faker<PaginatedList<ReactorFormula>> PagintedListFaker = new Faker<PaginatedList<ReactorFormula>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => ReactorFormulaFaker.Generate()).ToList());

        public static ReactorFormula ReactorFormula(Action<ReactorFormula> applyOverrides = null)
        {
            var reactorFormula = ReactorFormulaFaker.Generate();

            applyOverrides?.Invoke(reactorFormula);

            return reactorFormula;
        }

        public static PaginatedList<ReactorFormula> PaginatedReactorFormulas(Action<PaginatedList<ReactorFormula>> applyOverrides = null)
        {
            var list = PagintedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

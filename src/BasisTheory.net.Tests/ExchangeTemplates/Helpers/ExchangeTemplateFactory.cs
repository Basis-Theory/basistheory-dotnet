using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.ExchangeTemplates.Entities;
using BasisTheory.net.Tokens.Constants;
using Bogus;

namespace BasisTheory.net.Tests.ExchangeTemplates.Helpers
{
    public static class ExchangeTemplateFactory
    {
        public static readonly Faker<ExchangeTemplate> ExchangeTemplateFaker = new Faker<ExchangeTemplate>()
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
                f.Make(f.Random.Int(1, 5), () => ExchangeTemplateConfigurationFaker.Generate()))
            .RuleFor(t => t.RequestParameters, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => ExchangeTemplateRequestParameterFaker.Generate()));

        public static readonly Faker<ExchangeTemplateConfiguration> ExchangeTemplateConfigurationFaker =
            new Faker<ExchangeTemplateConfiguration>()
                .RuleFor(a => a.Name, (f, _) => f.Random.String2(20))
                .RuleFor(a => a.Type, (f, _) => f.Lorem.Word());

        public static readonly Faker<ExchangeTemplateRequestParameter> ExchangeTemplateRequestParameterFaker =
            new Faker<ExchangeTemplateRequestParameter>()
                .RuleFor(a => a.Name, (f, _) => f.Random.String2(20))
                .RuleFor(a => a.Description, (f, _) => f.Lorem.Sentence())
                .RuleFor(a => a.Type, (f, _) => f.Lorem.Word())
                .RuleFor(a => a.IsOptional, (f, _) => f.Random.Bool());

        public static readonly Faker<PaginatedList<ExchangeTemplate>> PagintedListFaker = new Faker<PaginatedList<ExchangeTemplate>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => ExchangeTemplateFaker.Generate()).ToList());

        public static ExchangeTemplate ExchangeTemplate(Action<ExchangeTemplate> applyOverrides = null)
        {
            var exchangeTemplate = ExchangeTemplateFaker.Generate();

            applyOverrides?.Invoke(exchangeTemplate);

            return exchangeTemplate;
        }

        public static PaginatedList<ExchangeTemplate> PaginatedExchangeTemplates(Action<PaginatedList<ExchangeTemplate>> applyOverrides = null)
        {
            var list = PagintedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Applications.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Applications.Helpers
{
    public static class ApplicationFactory
    {
        public static readonly Faker<Application> ApplicationFaker = new Faker<Application>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.Key, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.Type, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(t => t.Permissions, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Random.Word()))
            .RuleFor(a => a.CanCreateExpiringApplications, (f, _) => f.Random.Bool())
            .RuleFor(a => a.ExpiresAt, (f, _) => f.Date.FutureOffset());

        public static readonly Faker<AccessRule> AccessRuleFaker = new Faker<AccessRule>() 
            .RuleFor(a => a.Description, (f, _) => f.Lorem.Sentence())
            .RuleFor(a => a.Priority, (f, _) => f.Random.Int())
            .RuleFor(a => a.Container, (f, _) => $"/{f.Lorem.Word()}/")
            .RuleFor(a => a.Transform, (f, _) => f.PickRandom("mask", "redact", "reveal"))
            .RuleFor(a => a.Permissions, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Random.Word()));

        public static readonly Faker<PaginatedList<Application>> PaginatedListFaker = new Faker<PaginatedList<Application>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10)
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => ApplicationFaker.Generate()).ToList());

        public static Application Application(Action<Application> applyOverrides = null)
        {
            var application = ApplicationFaker.Generate();

            applyOverrides?.Invoke(application);

            return application;
        }
        
        public static AccessRule AccessRule(Action<AccessRule> applyOverrides = null)
        {
            var accessRule = AccessRuleFaker.Generate();

            applyOverrides?.Invoke(accessRule);

            return accessRule;
        }

        public static PaginatedList<Application> PaginatedApplications(Action<PaginatedList<Application>> applyOverrides = null)
        {
            var list = PaginatedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }
    }
}

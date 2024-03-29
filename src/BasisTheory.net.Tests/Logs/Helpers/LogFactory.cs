using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Logs.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Logs.Helpers;

public static class LogFactory
{
    public static readonly Faker<Log> LogFaker = new Faker<Log>()
        .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
        .RuleFor(a => a.ActorId, (_, _) => Guid.NewGuid())
        .RuleFor(a => a.ActorType, f => f.Random.Word())
        .RuleFor(a => a.EntityType, (f, _) => f.Lorem.Word())
        .RuleFor(a => a.EntityId, (f, _) => f.Lorem.Word())
        .RuleFor(a => a.Operation, (f, _) => f.Lorem.Word())
        .RuleFor(a => a.Message, (f, _) => f.Lorem.Sentence())
        .RuleFor(a => a.CreatedDate, (_, _) => DateTimeOffset.UtcNow);

    public static readonly Faker<PaginatedList<Log>> PaginatedListFaker = new Faker<PaginatedList<Log>>()
        .RuleFor(a => a.Pagination, (f, _) => new Pagination
        {
            After = f.Lorem.Word(),
            PageSize = f.Random.Number(1, 10),
        })
        .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => LogFaker.Generate()).ToList());

    public static PaginatedList<Log> PaginatedLogs(Action<PaginatedList<Log>> applyOverrides = null)
    {
        var list = PaginatedListFaker.Generate();

        applyOverrides?.Invoke(list);

        return list;
    }
}
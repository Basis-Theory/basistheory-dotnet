using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tenants.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Tenants.Helpers;

public class TenantMemberFactory
{
    public static readonly Faker<TenantMember> TenantMemberFaker = new Faker<TenantMember>()
        .RuleFor(i => i.Id, (_, _) => Guid.NewGuid())
        .RuleFor(i => i.TenantId, (_, _) => Guid.NewGuid())
        .RuleFor(i => i.Role, (f, _) => f.Lorem.Word())
        .RuleFor(i => i.User, (_, _) => UserModelFaker.Generate())
        .RuleFor(i => i.ExpirationDate, (f, _) => f.Date.PastOffset())
        .RuleFor(i => i.CreatedBy, (_, _) => Guid.NewGuid())
        .RuleFor(i => i.CreatedDate, (f, _) => f.Date.PastOffset())
        .RuleFor(i => i.ModifiedBy, (_, _) => Guid.NewGuid())
        .RuleFor(i => i.ModifiedDate, (f, _) => f.Date.PastOffset());

    public static readonly Faker<UserModel> UserModelFaker =
        new Faker<UserModel>()
            .RuleFor(u => u.UserId, (_, _) => Guid.NewGuid())
            .RuleFor(u => u.Email, (f, _) => f.Person.Email)
            .RuleFor(u => u.FirstName, (f, _) => f.Person.FirstName)
            .RuleFor(u => u.LastName, (f, _) => f.Person.LastName)
            .RuleFor(u => u.Picture, (f, _) => f.Internet.Url());

    public static readonly Faker<PaginatedList<TenantMember>> PaginatedListFaker =
        new Faker<PaginatedList<TenantMember>>()
            .RuleFor(i => i.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10)
            })
            .RuleFor(i => i.Data,
                (f, _) => f.Make(f.Random.Int(5, 10), () => TenantMemberFaker.Generate()).ToList());

    public static TenantMember TenantMember(Action<TenantMember> applyOverrides = null)
    {
        var tenantMember = TenantMemberFaker.Generate();

        applyOverrides?.Invoke(tenantMember);

        return tenantMember;
    }

    public static PaginatedList<TenantMember> PaginatedTenantMembers(
        Action<PaginatedList<TenantMember>> applyOverrides = null)
    {
        var list = PaginatedListFaker.Generate();

        applyOverrides?.Invoke(list);

        return list;
    }
}

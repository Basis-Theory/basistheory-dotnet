using System;
using System.Linq;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tenants.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Tenants.Helpers;

public class TenantInvitationFactory
{
    public static readonly Faker<TenantInvitation> TenantInvitationFaker = new Faker<TenantInvitation>()
        .RuleFor(i => i.Id, (_, _) => Guid.NewGuid())
        .RuleFor(i => i.TenantId, (_, _) => Guid.NewGuid())
        .RuleFor(i => i.Email, (f, _) => f.Internet.Email())
        .RuleFor(i => i.Status, (_, _) => TenantInvitationStatus.PENDING)
        .RuleFor(i => i.ExpirationDate, (f, _) => f.Date.PastOffset())
        .RuleFor(i => i.CreatedBy, (_, _) => Guid.NewGuid())
        .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
        .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
        .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset());

    public static readonly Faker<PaginatedList<TenantInvitation>> PaginatedListFaker =
        new Faker<PaginatedList<TenantInvitation>>()
            .RuleFor(i => i.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10)
            })
            .RuleFor(i => i.Data,
                (f, _) => f.Make(f.Random.Int(5, 10), () => TenantInvitationFaker.Generate()).ToList());

    public static TenantInvitation TenantInvitation(Action<TenantInvitation> applyOverrides = null)
    {
        var tenantInvitation = TenantInvitationFaker.Generate();

        applyOverrides?.Invoke(tenantInvitation);

        return tenantInvitation;
    }

    public static PaginatedList<TenantInvitation> PaginatedTenantInvitations(
        Action<PaginatedList<TenantInvitation>> applyOverrides = null)
    {
        var list = PaginatedListFaker.Generate();

        applyOverrides?.Invoke(list);

        return list;
    }
}

using System;
using BasisTheory.net.Tenants.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Tenants.Helpers
{
    public static class TenantFactory
    {
        public static readonly Faker<Tenant> TenantFaker = new Faker<Tenant>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.OwnerId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Name, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.CreatedBy, (f, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (f, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset());

        public static Tenant Tenant(Action<Tenant> applyOverrides = null)
        {
            var tenant = TenantFaker.Generate();

            applyOverrides?.Invoke(tenant);

            return tenant;
        }
    }
}

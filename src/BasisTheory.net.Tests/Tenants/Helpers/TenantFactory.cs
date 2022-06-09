using System;
using System.Collections.Generic;
using System.Linq;
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
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.Settings, (f, _) => f.Make(10, () =>
                new KeyValuePair<string, string>(f.Random.String2(10), f.Random.String2(10)))
                .ToDictionary(x => x.Key, x => x.Value));

        public static Tenant Tenant(Action<Tenant> applyOverrides = null)
        {
            var tenant = TenantFaker.Generate();

            applyOverrides?.Invoke(tenant);

            return tenant;
        }
    }
}

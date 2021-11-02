using System;
using System.Collections.Generic;
using BasisTheory.net.Tenants.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Tenants.Helpers
{
    public static class TenantUsageReportFactory
    {
        public static readonly Faker<TenantUsageReport> TenantUsageReportFaker = new Faker<TenantUsageReport>()
            .RuleFor(x => x.TokenReport, _ => TokenReportFaker.Generate());

        public static readonly Faker<TokenReport> TokenReportFaker = new Faker<TokenReport>()
            .RuleFor(x => x.IncludedMonthlyActiveTokens, f => f.Random.Long())
            .RuleFor(x => x.MonthlyActiveTokens, f => f.Random.Long())
            .RuleFor(x => x.TokenTypeMetrics, f => new Dictionary<string, TokenTypeMetrics>
            {
                {
                    f.Random.Words(),
                    new TokenTypeMetrics { Count = f.Random.Long(), LastCreatedDate = f.Date.PastOffset() }
                }
            });

        public static TenantUsageReport TenantUsageReport(Action<TenantUsageReport> applyOverrides = null)
        {
            var tenantUsageReport = TenantUsageReportFaker.Generate();

            applyOverrides?.Invoke(tenantUsageReport);

            return tenantUsageReport;
        }
    }
}

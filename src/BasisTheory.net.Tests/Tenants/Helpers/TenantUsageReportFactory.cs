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
            }).RuleFor(x => x.MonthlyActiveTokenHistory, f => MonthlyActiveTokenHistoryFaker.Generate(f.Random.Int(1, 10)));

        public static readonly Faker<MonthlyActiveTokenHistory> MonthlyActiveTokenHistoryFaker =
            new Faker<MonthlyActiveTokenHistory>()
                .RuleFor(x => x.Count, f => f.Random.Long(0))
                .RuleFor(x => x.Year, f => f.Random.Int(1000, 9999))
                .RuleFor(x => x.Month, f => f.Random.Int(1, 12));

        public static TenantUsageReport TenantUsageReport(Action<TenantUsageReport> applyOverrides = null)
        {
            var tenantUsageReport = TenantUsageReportFaker.Generate();

            applyOverrides?.Invoke(tenantUsageReport);

            return tenantUsageReport;
        }
    }
}

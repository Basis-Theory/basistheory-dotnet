using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Atomic.Banks.Entities;
using BasisTheory.net.Common.Responses;
using Bogus;

namespace BasisTheory.net.Tests.Atomic.Banks.Helpers
{
    public static class AtomicBankFactory
    {
        public static readonly Faker<AtomicBank> AtomicBankFaker = new Faker<AtomicBank>()
            .RuleFor(a => a.Id, (_, _) => Guid.NewGuid().ToString())
            .RuleFor(a => a.TenantId, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.Type, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.CreatedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.ModifiedBy, (_, _) => Guid.NewGuid())
            .RuleFor(a => a.ModifiedDate, (f, _) => f.Date.PastOffset())
            .RuleFor(a => a.Bank, (_, _) => BankFaker.Generate())
            .RuleFor(a => a.Fingerprint, (f, _) => f.Lorem.Word())
            .RuleFor(t => t.Metadata, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Word()))
                    .ToDictionary(x => x.Key, x => x.Value));

        public static readonly Faker<Bank> BankFaker = new Faker<Bank>()
            .RuleFor(a => a.RoutingNumber, (f, _) => f.Finance.RoutingNumber())
            .RuleFor(a => a.AccountNumber, (f, _) => f.Finance.Account());

        public static readonly Faker<PaginatedList<AtomicBank>> PaginatedListFaker = new Faker<PaginatedList<AtomicBank>>()
            .RuleFor(a => a.Pagination, (f, _) => new Pagination
            {
                TotalItems = f.Random.Number(1, 10),
                TotalPages = f.Random.Number(1, 10),
                PageNumber = f.Random.Number(1, 10),
                PageSize = f.Random.Number(1, 10),
            })
            .RuleFor(t => t.Data, (f, _) => f.Make(f.Random.Int(5, 10), () => AtomicBankFaker.Generate()).ToList());

        public static AtomicBank AtomicBank(Action<AtomicBank> applyOverrides = null)
        {
            var atomicBank = AtomicBankFaker.Generate();

            applyOverrides?.Invoke(atomicBank);

            return atomicBank;
        }

        public static PaginatedList<AtomicBank> PaginatedBanks(Action<PaginatedList<AtomicBank>> applyOverrides = null)
        {
            var list = PaginatedListFaker.Generate();

            applyOverrides?.Invoke(list);

            return list;
        }

        public static Bank Bank(Action<Bank> applyOverrides = null)
        {
            var bank = BankFaker.Generate();

            applyOverrides?.Invoke(bank);

            return bank;
        }
    }
}

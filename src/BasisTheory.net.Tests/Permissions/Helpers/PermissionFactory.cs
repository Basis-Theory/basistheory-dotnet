using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Permissions.Entities;
using Bogus;

namespace BasisTheory.net.Tests.Permissions.Helpers
{
    public static class PermissionFactory
    {
        public static readonly Faker<Permission> PermissionFaker = new Faker<Permission>()
            .RuleFor(a => a.Type, (f, _) => f.Lorem.Word())
            .RuleFor(a => a.Description, (f, _) => f.Lorem.Sentence())
            .RuleFor(a => a.ApplicationTypes, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Lorem.Word()));

        public static List<Permission> PermissionList()
        {
            var faker = new Faker();
            return faker.Make(faker.Random.Int(5, 10), () => PermissionFaker.Generate()).ToList();
        }
    }
}

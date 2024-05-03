using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.ApplicationKeys.Entities;
using Bogus;

namespace BasisTheory.net.Tests.ApplicationKeys.Helpers;

public static class ApplicationKeyFactory
{
    public static readonly Faker<ApplicationKey> ApplicationKeyFaker = new Faker<ApplicationKey>()
        .RuleFor(a => a.Id, (f) => Guid.NewGuid())
        .RuleFor(a => a.Key, (_, _) => Guid.NewGuid())
        .RuleFor(a => a.CreatedBy, (_, _) => Guid.NewGuid())
        .RuleFor(a => a.CreatedAt, (f, _) => f.Date.PastOffset().ToString());

    public static readonly Faker<List<ApplicationKey>> ApplicationKeysFaker =
        new Faker<List<ApplicationKey>>()
            .CustomInstantiator(f => f.Make(f.Random.Int(1, 3), () => ApplicationKeyFaker.Generate()).ToList());
    public static List<ApplicationKey> ApplicationKeys(
        Action<List<ApplicationKey>> applyOverrides = null)
    {
        var list = ApplicationKeysFaker.Generate();

        applyOverrides?.Invoke(list);

        return list;
    }


    public static ApplicationKey ApplicationKey(Action<ApplicationKey> applyOverrides = null)
    {
        var applicationKey = ApplicationKeyFaker.Generate();

        applyOverrides?.Invoke(applicationKey);

        return applicationKey;
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Errors;
using Bogus;

namespace BasisTheory.net.Tests.Helpers
{
    public static class BasisTheoryErrorFactory
    {
        public static readonly Faker<BasisTheoryError> BasisTheoryErrorFaker = new Faker<BasisTheoryError>()
            .RuleFor(a => a.Title, (f, _) => f.Random.Word())
            .RuleFor(a => a.Detail, (f, _) => f.Lorem.Sentence())
            .RuleFor(a => a.Status, (_, _) => 400)
            .RuleFor(t => t.Errors, (f, _) =>
                f.Make(f.Random.Int(1, 5), () => KeyValuePair.Create(f.Random.String(10, 20, 'A', 'Z'), f.Lorem.Sentence()))
                    .ToDictionary(x => x.Key, x => new[] { x.Value }));

        public static BasisTheoryError BasisTheoryError(Action<BasisTheoryError> applyOverrides = null)
        {
            var error = BasisTheoryErrorFaker.Generate();

            applyOverrides?.Invoke(error);

            return error;
        }
    }
}

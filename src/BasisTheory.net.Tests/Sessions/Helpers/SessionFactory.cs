using System;
using System.Collections.Generic;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.Sessions.Requests;
using BasisTheory.net.Tests.Applications.Helpers;
using Bogus;

namespace BasisTheory.net.Tests.Sessions.Helpers;

public static class SessionFactory
{
    public static readonly Faker<AuthorizeSessionRequest> AuthorizeSessionRequestFaker =
        new Faker<AuthorizeSessionRequest>()
            .RuleFor(asr => asr.Nonce, (f, _) => f.Random.Word())
            .RuleFor(asr => asr.ExpiresAt, (f, _) => f.Date.FutureOffset())
            .RuleFor(asr => asr.Permissions, (f, _) => f.Make(f.Random.Int(1, 5), () => f.Random.Word()))
            .RuleFor(asr => asr.Rules, (f, _) => new List<AccessRule> { ApplicationFactory.AccessRule() });

    public static AuthorizeSessionRequest AuthorizeSessionRequest(
        Action<AuthorizeSessionRequest> applyOverrides = null)
    {
        var authorizeSessionRequest = AuthorizeSessionRequestFaker.Generate();

        applyOverrides?.Invoke(authorizeSessionRequest);

        return authorizeSessionRequest;
    }
}
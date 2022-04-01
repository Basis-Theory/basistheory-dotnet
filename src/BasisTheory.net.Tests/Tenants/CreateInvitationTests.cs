using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tests.Tenants.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Tenants;

public class CreateInvitationTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public CreateInvitationTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>>)(
                    async (client, tenantInvitation, options) =>
                        await client.CreateInvitationAsync(tenantInvitation, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>>)(
                    (client, tenantInvitation, options) =>
                        Task.FromResult(client.CreateInvitation(tenantInvitation, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateInvitation(
        Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateInvitationWithPerRequestApiKey(
        Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateInvitationWithCorrelationId(
        Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, TenantInvitation, RequestOptions, Task<TenantInvitation>> mut)
    {
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tests.Tenants.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Tenants;

public class ResendInvitationTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public ResendInvitationTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>>)(
                    async (client, tenantInvitationId, options) =>
                        await client.ResendInvitationAsync(tenantInvitationId, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>>)(
                    async (client, tenantInvitationId, options) =>
                        await client.ResendInvitationAsync(tenantInvitationId.ToString(), options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>>)(
                    (client, tenantInvitationId, options) =>
                        Task.FromResult(client.ResendInvitation(tenantInvitationId, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>>)(
                    (client, tenantInvitationId, options) =>
                        Task.FromResult(client.ResendInvitation(tenantInvitationId.ToString(), options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldResendInvitation(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldResendInvitationWithPerRequestApiKey(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldResendInvitationWithCorrelationId(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }
}

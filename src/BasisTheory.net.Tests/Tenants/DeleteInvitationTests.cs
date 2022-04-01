using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tenants.Requests;
using BasisTheory.net.Tests.Tenants.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Tenants;

public class DeleteInvitationTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public DeleteInvitationTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    async (client, tenantInvitationId, options) =>
                        await client.DeleteInvitationAsync(tenantInvitationId, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, string, RequestOptions, Task>)(
                    async (client, tenantInvitationId, options) =>
                        await client.DeleteInvitationAsync(tenantInvitationId, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, string, RequestOptions, Task>)(
                    (client, tenantInvitationId, options) =>
                        Task.Run(() => client.DeleteInvitation(tenantInvitationId, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    (client, tenantInvitationId, options) =>
                        Task.Run(() => client.DeleteInvitation(tenantInvitationId, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteInvitation(
        Func<ITenantClient, TenantMember, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteInvitationWithPerRequestApiKey(
        Func<ITenantClient, TenantMember, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteInvitationWithCorrelationId(
        Func<ITenantClient, TenantMember, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, TenantMember, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, TenantMember, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, TenantMember, RequestOptions, Task> mut)
    {
    }
}

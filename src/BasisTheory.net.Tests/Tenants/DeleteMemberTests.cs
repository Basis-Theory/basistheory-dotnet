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

public class DeleteMemberTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public DeleteMemberTests(TenantFixture fixture)
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
                    async (client, tenantMemberId, options) =>
                        await client.DeleteMemberAsync(tenantMemberId, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    async (client, tenantMemberId, options) =>
                        await client.DeleteMemberAsync(tenantMemberId.ToString(), options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    (client, tenantMemberId, options) =>
                        Task.Run(() => client.DeleteMember(tenantMemberId, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    (client, tenantMemberId, options) =>
                        Task.Run(() => client.DeleteMember(tenantMemberId.ToString(), options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteMember(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteMemberWithPerRequestApiKey(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteMemberWithCorrelationId(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
    }
}

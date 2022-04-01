using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tenants.Requests;
using BasisTheory.net.Tests.Tenants.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Tenants;

public class GetInvitationsTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public GetInvitationsTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions,
                    Task<PaginatedList<TenantInvitation>>>)(
                    async (client, tenantInvitationsGetRequest, options) =>
                        await client.GetInvitationsAsync(tenantInvitationsGetRequest, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions,
                    Task<PaginatedList<TenantInvitation>>>)(
                    (client, tenantInvitation, options) =>
                        Task.FromResult(client.GetInvitations(tenantInvitation, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitations(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithPagination(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithAllParameters(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithPerRequestApiKey(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithCorrelationId(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
    }
}

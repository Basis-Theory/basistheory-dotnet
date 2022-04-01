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

public class GetMembersTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public GetMembersTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, TenantMemberGetRequest, RequestOptions,
                    Task<PaginatedList<TenantMember>>>)(
                    async (client, tenantMemberGetRequest, options) =>
                        await client.GetMembersAsync(tenantMemberGetRequest, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, TenantMemberGetRequest, RequestOptions,
                    Task<PaginatedList<TenantMember>>>)(
                    (client, tenantMemberGetRequest, options) =>
                        Task.FromResult(client.GetMembers(tenantMemberGetRequest, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembers(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithPagination(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithAllParameters(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithPerRequestApiKey(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithCorrelationId(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
    }
}

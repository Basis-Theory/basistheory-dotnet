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

public class GetInvitationByIdTests : IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public GetInvitationByIdTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>>)(
                    async (client, tenantInvitationId, tenantsGetByIdRequest, options) =>
                        await client.GetInvitationByIdAsync(tenantInvitationId, tenantsGetByIdRequest, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>>)(
                    async (client, tenantInvitationId, tenantsGetByIdRequest, options) =>
                        await client.GetInvitationByIdAsync(tenantInvitationId.ToString(), tenantsGetByIdRequest,
                            options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>>)(
                    (client, tenantInvitationId, tenantsGetByIdRequest, options) =>
                        Task.FromResult(client.GetInvitationById(tenantInvitationId, tenantsGetByIdRequest, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>>)(
                    (client, tenantInvitationId, tenantsGetByIdRequest, options) =>
                        Task.FromResult(client.GetInvitationById(tenantInvitationId.ToString(), tenantsGetByIdRequest,
                            options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationById(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationByIdWithPerRequestApiKey(
        Func<ITenantClient, Guid, RequestOptions, Task<TenantInvitation>> mut)
    {
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationByIdWithCorrelationId(
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

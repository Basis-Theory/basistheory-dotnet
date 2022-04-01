using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tenants.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tenants.Helpers;
using Newtonsoft.Json;
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
        Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>> mut)
    {
        var content = TenantInvitationFactory.TenantInvitation();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, null, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationByIdWithPerRequestApiKey(
        Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TenantInvitationFactory.TenantInvitation();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationByIdWithCorrelationId(
        Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var content = TenantInvitationFactory.TenantInvitation();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, Guid, TenantsGetByIdRequest, RequestOptions, Task<TenantInvitation>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tenants.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tenants.Helpers;
using Newtonsoft.Json;
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
        var content = TenantInvitationFactory.PaginatedTenantInvitations();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tenants/self/invitations", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsByStatus(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var invitationStatus = _fixture.Faker.Lorem.Word();
        
        var content = TenantInvitationFactory.PaginatedTenantInvitations();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TenantInvitationsGetRequest()
        {
            Status = invitationStatus
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations?status={invitationStatus}",
            requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithPagination(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var size = _fixture.Faker.Random.Int(1, 20);
        var page = _fixture.Faker.Random.Int(1, 20);

        var content = TenantInvitationFactory.PaginatedTenantInvitations();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TenantInvitationsGetRequest()
        {
            PageSize = size,
            Page = page
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithAllParameters(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var invitationStatus = _fixture.Faker.Lorem.Word();
        var size = _fixture.Faker.Random.Int(1, 20);
        var page = _fixture.Faker.Random.Int(1, 20);

        var content = TenantInvitationFactory.PaginatedTenantInvitations();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TenantInvitationsGetRequest()
        {
            Status = invitationStatus,
            PageSize = size,
            Page = page
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations?page={page}&size={size}&status={invitationStatus}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithPerRequestApiKey(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TenantInvitationFactory.PaginatedTenantInvitations();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tenants/self/invitations", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetInvitationsWithCorrelationId(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var content = TenantInvitationFactory.PaginatedTenantInvitations();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tenants/self/invitations", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, TenantInvitationsGetRequest, RequestOptions, Task<PaginatedList<TenantInvitation>>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}

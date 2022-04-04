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
        var content = TenantMemberFactory.PaginatedTenantMembers();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tenants/self/members", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersByUserIds(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
        var memberUserId1 = Guid.NewGuid();
        var memberUserId2 = Guid.NewGuid();

        var content = TenantMemberFactory.PaginatedTenantMembers();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TenantMemberGetRequest()
        {
            MemberUserIds = new List<Guid> { memberUserId1, memberUserId2 }
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/members?user_id={memberUserId1}&user_id={memberUserId2}",
            requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithPagination(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
        var size = _fixture.Faker.Random.Int(1, 20);
        var page = _fixture.Faker.Random.Int(1, 20);

        var content = TenantMemberFactory.PaginatedTenantMembers();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TenantMemberGetRequest()
        {
            PageSize = size,
            Page = page
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/members?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithAllParameters(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
        var memberUserId = Guid.NewGuid();
        var size = _fixture.Faker.Random.Int(1, 20);
        var page = _fixture.Faker.Random.Int(1, 20);

        var content = TenantMemberFactory.PaginatedTenantMembers();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TenantMemberGetRequest()
        {
            MemberUserIds = new List<Guid> { memberUserId },
            PageSize = size,
            Page = page
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tenants/self/members?page={page}&size={size}&user_id={memberUserId}",
            requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithPerRequestApiKey(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TenantMemberFactory.PaginatedTenantMembers();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tenants/self/members", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetMembersWithCorrelationId(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var content = TenantMemberFactory.PaginatedTenantMembers();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tenants/self/members", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
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
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
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
        Func<ITenantClient, TenantMemberGetRequest, RequestOptions, Task<PaginatedList<TenantMember>>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}

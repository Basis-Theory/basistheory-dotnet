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

public class UpdateMemberTests: IClassFixture<TenantFixture>
{
    private readonly TenantFixture _fixture;

    public UpdateMemberTests(TenantFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    async (client, memberId, request, options) => await client.UpdateMemberAsync(memberId, request, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    async (client, memberId, request, options) => await client.UpdateMemberAsync(memberId.ToString(), request, options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    (client, memberId, request, options) => Task.FromResult(client.UpdateMember(memberId, request, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>>)(
                    (client, memberId, request, options) => Task.FromResult(client.UpdateMember(memberId.ToString(), request, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldUpdate(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        var content = TenantMemberFactory.TenantMemberFaker.Generate();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var updateRequest = new TenantMemberUpdateRequest
        {
            Role = content.Role
        };
        
        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, updateRequest, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Put, requestMessage.Method);
        Assert.Equal($"/tenants/self/members/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldUpdateWithPerRequestApiKey(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TenantMemberFactory.TenantMemberFaker.Generate();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var updateRequest = new TenantMemberUpdateRequest
        {
            Role = content.Role
        };

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, updateRequest, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Put, requestMessage.Method);
        Assert.Equal($"/tenants/self/members/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldUpdateWithCustomHeaders(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var expectedIdempotencyKey = Guid.NewGuid().ToString();

        var content = TenantMemberFactory.TenantMemberFaker.Generate();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var updateRequest = new TenantMemberUpdateRequest
        {
            Role = content.Role
        };

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, updateRequest, new RequestOptions
        {
            CorrelationId = expectedCorrelationId,
            IdempotencyKey = expectedIdempotencyKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Put, requestMessage.Method);
        Assert.Equal($"/tenants/self/members/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        Assert.Equal(expectedIdempotencyKey, requestMessage.Headers.GetValues("BT-IDEMPOTENCY-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new TenantMemberUpdateRequest(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new TenantMemberUpdateRequest(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITenantClient, Guid, TenantMemberUpdateRequest, RequestOptions, Task<TenantMember>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new TenantMemberUpdateRequest(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
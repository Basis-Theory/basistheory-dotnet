using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tenants.Helpers;
using Newtonsoft.Json;
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
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    async (client, tenantInvitationId, options) =>
                        await client.DeleteInvitationAsync(tenantInvitationId.ToString(), options)
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    (client, tenantInvitationId, options) =>
                        Task.Run(() => client.DeleteInvitation(tenantInvitationId, options))
                )
            };
            yield return new object[]
            {
                (Func<ITenantClient, Guid, RequestOptions, Task>)(
                    (client, tenantInvitationId, options) =>
                        Task.Run(() => client.DeleteInvitation(tenantInvitationId.ToString(), options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteInvitation(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
        var invitationId = Guid.NewGuid();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

        await mut(_fixture.Client, invitationId, null);

        Assert.Equal(HttpMethod.Delete, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations/{invitationId}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteInvitationWithPerRequestApiKey(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var invitationId = Guid.NewGuid();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

        await mut(_fixture.Client, invitationId, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(HttpMethod.Delete, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations/{invitationId}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteInvitationWithCorrelationId(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var invitationId = Guid.NewGuid();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

        await mut(_fixture.Client, invitationId, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(HttpMethod.Delete, requestMessage.Method);
        Assert.Equal($"/tenants/self/invitations/{invitationId}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITenantClient, Guid, RequestOptions, Task> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}

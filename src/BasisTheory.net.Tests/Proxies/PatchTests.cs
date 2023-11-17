using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Proxies;
using BasisTheory.net.Proxies.Entities;
using BasisTheory.net.Proxies.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Proxies.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Proxies;

public class PatchTests : IClassFixture<ProxyFixture>
{
    private readonly ProxyFixture _fixture;

    public PatchTests(ProxyFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object []
            {
                (Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>>)(
                    async (client, proxyId, proxy, options) => await client.PatchAsync(proxyId, proxy, options)
                )
            };
            yield return new object []
            {
                (Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>>)(
                    async (client, proxyId, proxy, options) => await client.PatchAsync(proxyId.ToString(), proxy, options)
                )
            };
            yield return new object []
            {
                (Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>>)(
                    (client, proxyId, proxy, options) => Task.FromResult(client.Patch(proxyId, proxy, options))
                )
            };
            yield return new object []
            {
                (Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>>)(
                    (client, proxyId, proxy, options) => Task.FromResult(client.Patch(proxyId.ToString(), proxy, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldPatch(Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>> mut)
    {
        var content = ProxyFactory.Proxy();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var request = ProxyFactory.ProxyPatchRequest();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, request, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Patch, requestMessage.Method);
        Assert.Equal("application/merge-patch+json", requestMessage?.Content?.Headers.ContentType?.MediaType);
        Assert.Equal($"/proxies/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldPatchWithPerRequestApiKey(Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = ProxyFactory.Proxy();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var request = ProxyFactory.ProxyPatchRequest();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, request, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Patch, requestMessage.Method);
        Assert.Equal("application/merge-patch+json", requestMessage?.Content?.Headers.ContentType?.MediaType);
        Assert.Equal($"/proxies/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldPatchWithCustomHeaders(Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var expectedIdempotencyKey = Guid.NewGuid().ToString();
            
        var content = ProxyFactory.Proxy();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var request = ProxyFactory.ProxyPatchRequest();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content.Id, request, new RequestOptions
        {
            CorrelationId = expectedCorrelationId,
            IdempotencyKey = expectedIdempotencyKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Patch, requestMessage.Method);
        Assert.Equal("application/merge-patch+json", requestMessage?.Content?.Headers.ContentType?.MediaType);
        Assert.Equal($"/proxies/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        Assert.Equal(expectedIdempotencyKey, requestMessage.Headers.GetValues("BT-IDEMPOTENCY-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new ProxyPatchRequest(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new ProxyPatchRequest(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IProxyClient, Guid, ProxyPatchRequest, RequestOptions, Task<Proxy>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new ProxyPatchRequest(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
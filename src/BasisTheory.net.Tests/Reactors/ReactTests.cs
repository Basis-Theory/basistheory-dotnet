using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Reactors;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Reactors.Helpers;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Reactors;

public class ReactTests : IClassFixture<ReactorFixture>
{
    private readonly ReactorFixture _fixture;
    private readonly Faker _faker = new();

    public ReactTests(ReactorFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>) (
                    async (client, reactorId, request, options) =>
                        await client.ReactAsync(reactorId, request, options)
                )
            };
            yield return new object[]
            {
                (Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>) (
                    async (client, reactorId, request, options) =>
                        await client.ReactAsync(reactorId.ToString(), request, options)
                )
            };
            yield return new object[]
            {
                (Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>) (
                    (client, reactorId, request, options) =>
                        Task.FromResult(client.React(reactorId, request, options))
                )
            };
            yield return new object[]
            {
                (Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>) (
                    (client, reactorId, request, options) =>
                        Task.FromResult(client.React(reactorId.ToString(), request, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldReact(Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        var reactorId = Guid.NewGuid();
        var request = ReactorFactory.ReactRequest();

        var content = ReactorFactory.ReactResponse();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, reactorId, request, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal($"/reactors/{reactorId}/react", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }
    
    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldReactWithCallbackUrlAndTimeout(Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        var reactorId = Guid.NewGuid();
        var request = ReactorFactory.ReactRequest(r =>
        {
            r.CallbackUrl = _faker.Internet.Url();
            r.TimeoutMs = _faker.Random.Int(10000, 210000);
        });

        var content = ReactorFactory.ReactResponse();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, reactorId, request, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal($"/reactors/{reactorId}/react", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldReactWithPerRequestApiKey(
        Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();
        var reactorId = Guid.NewGuid();
        var request = ReactorFactory.ReactRequest();

        var content = ReactorFactory.ReactResponse();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, reactorId, request, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal($"/reactors/{reactorId}/react", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldReactWithCustomHeaders(
        Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var expectedIdempotencyKey = Guid.NewGuid().ToString();
        var reactorId = Guid.NewGuid();
        var request = ReactorFactory.ReactRequest();

        var content = ReactorFactory.ReactResponse();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, reactorId, request, new RequestOptions
        {
            CorrelationId = expectedCorrelationId,
            IdempotencyKey = expectedIdempotencyKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal($"/reactors/{reactorId}/react", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        Assert.Equal(expectedIdempotencyKey, requestMessage.Headers.GetValues("BT-IDEMPOTENCY-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception =
            await Assert.ThrowsAsync<BasisTheoryException>(() =>
                mut(_fixture.Client, Guid.NewGuid(), new ReactRequest(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(
        Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception =
            await Assert.ThrowsAsync<BasisTheoryException>(() =>
                mut(_fixture.Client, Guid.NewGuid(), new ReactRequest(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<IReactorClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception =
            await Assert.ThrowsAsync<BasisTheoryException>(() =>
                mut(_fixture.Client, Guid.NewGuid(), new ReactRequest(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
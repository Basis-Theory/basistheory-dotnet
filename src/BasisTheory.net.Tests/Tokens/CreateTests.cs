using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using BasisTheory.net.Tokens;
using BasisTheory.net.Tokens.Entities;
using BasisTheory.net.Tokens.Requests;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Tokens;

public class CreateTests : IClassFixture<TokenFixture>
{
    private readonly TokenFixture _fixture;

    public CreateTests(TokenFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object []
            {
                (Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>>)(
                    async (client, token, options) => await client.CreateAsync(token, options)
                )
            };
            yield return new object []
            {
                (Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>>)(
                    async (client, token, options) => await client.CreateAsync(token.Data, token.Metadata, options)
                )
            };
            yield return new object []
            {
                (Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>>)(
                    (client, token, options) => Task.FromResult(client.Create(token, options))
                )
            };
            yield return new object []
            {
                (Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>>)(
                    (client, token, options) => Task.FromResult(client.Create(token.Data, token.Metadata, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreate(Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>> mut)
    {
        var content = TokenFactory.Token();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var request = TokenFactory.TokenCreateRequest();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, request, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokens", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateWithPerRequestApiKey(Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TokenFactory.Token();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var request = TokenFactory.TokenCreateRequest();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, request, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokens", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateWithCorrelationId(Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var content = TokenFactory.Token();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var request = TokenFactory.TokenCreateRequest();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, request, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokens", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new TokenCreateRequest(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new TokenCreateRequest(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, TokenCreateRequest, RequestOptions, Task<Token>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new TokenCreateRequest(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
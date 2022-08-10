using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tokenize.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using BasisTheory.net.Tokenize;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BasisTheory.net.Tests.Tokenize;

public class TokenizeTests : IClassFixture<TokenizeFixture>
{
    private readonly TokenizeFixture _fixture;

    public TokenizeTests(TokenizeFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>>)(
                    async (client, tokens, options) => await client.TokenizeAsync(tokens, options)
                )
            };
            yield return new object[]
            {
                (Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>>)(
                    (client, tokens, options) => Task.FromResult((JToken)client.Tokenize(tokens, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldTokenize(Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>> mut)
    {
        var content = TokenFactory.Token();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokenize", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateWithPerRequestApiKey(Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TokenFactory.Token();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokenize", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldCreateWithCorrelationId(Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var content = TokenFactory.Token();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, content, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokenize", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new Token(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new Token(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(
        Func<ITokenizeClient, dynamic, RequestOptions, Task<JToken>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new Token(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
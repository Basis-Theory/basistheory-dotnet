using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using BasisTheory.net.Tokens;
using BasisTheory.net.Tokens.Entities;
using BasisTheory.net.Tokens.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BasisTheory.net.Tests.Tokens;

public class SearchTests : IClassFixture<TokenFixture>
{
    private readonly TokenFixture _fixture;

    public SearchTests(TokenFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>>) (
                    async (client, request, options) => await client.SearchAsync(request, options)
                )
            };
            yield return new object[]
            {
                (Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>>) (
                    (client, request, options) => Task.FromResult(client.Search(request, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldSearch(
        Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);
        var expectedRequestBody = new
        {
            query = _fixture.Faker.Random.Words(),
            page = _fixture.Faker.Random.Int(),
            size = _fixture.Faker.Random.Int(),
        };

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TokenSearchRequest
        {
            Query = expectedRequestBody.query,
            Page = expectedRequestBody.page,
            PageSize = expectedRequestBody.size
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokens/search", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);

        var actualRequestBody = JsonConvert.DeserializeObject<JObject>(await requestMessage.Content!.ReadAsStringAsync());
        Assert.Equal(expectedRequestBody.query, actualRequestBody!["query"]);
        Assert.Equal(expectedRequestBody.page, actualRequestBody!["page"]);
        Assert.Equal(expectedRequestBody.size, actualRequestBody!["size"]);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldSearchWithPerRequestApiKey(
        Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokens/search", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldSearchWithCorrelationId(
        Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Post, requestMessage.Method);
        Assert.Equal("/tokens/search", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
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
        Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
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
        Func<ITokenClient, TokenSearchRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}

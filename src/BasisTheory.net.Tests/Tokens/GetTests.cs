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
using Xunit;

namespace BasisTheory.net.Tests.Tokens;

public class GetTests : IClassFixture<TokenFixture>
{
    private readonly TokenFixture _fixture;

    public GetTests(TokenFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object []
            {
                (Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>)(
                    async (client, request, options) => await client.GetAsync(request, options)
                )
            };
            yield return new object []
            {
                (Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>)(
                    (client, request, options) => Task.FromResult(client.Get(request, options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetAll(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, null, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tokens", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetByType(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var type1 = Guid.NewGuid().ToString();
        var type2 = Guid.NewGuid().ToString();

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TokenGetRequest
        {
            Types = new List<string> { type1, type2 }
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tokens?type={type1}&type={type2}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetByIds(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var tokenId1 = Guid.NewGuid().ToString();
        var tokenId2 = Guid.NewGuid().ToString();

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TokenGetRequest
        {
            TokenIds = new List<string> { tokenId1, tokenId2 }
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tokens?id={tokenId1}&id={tokenId2}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetWithMetadataQuery(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var metadata1 = new KeyValuePair<string ,string>(
            _fixture.Faker.Random.String2(10, 20), _fixture.Faker.Random.String2(10, 20));
        var metadata2 = new KeyValuePair<string ,string>(
            _fixture.Faker.Random.String2(10, 20), _fixture.Faker.Random.String2(10, 20));

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TokenGetRequest
        {
            MetadataQuery = new Dictionary<string, string>() { metadata1, metadata2 }
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tokens?metadata.{metadata1.Key}={metadata1.Value}&metadata.{metadata2.Key}={metadata2.Value}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetWithPagination(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var size = _fixture.Faker.Random.Int(1, 20);
        var page = _fixture.Faker.Random.Int(1, 20);

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TokenGetRequest
        {
            PageSize = size,
            Page = page
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tokens?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetWithAllParameters(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var type = _fixture.Faker.Lorem.Word();
        var tokenId = Guid.NewGuid().ToString();
        var metadataQuery = new KeyValuePair<string, string>(
            _fixture.Faker.Random.String2(10, 20), _fixture.Faker.Random.String2(10, 20));
        var size = _fixture.Faker.Random.Int(1, 20);
        var page = _fixture.Faker.Random.Int(1, 20);

        var content = TokenFactory.PaginatedTokens();
        var expectedSerialized = JsonConvert.SerializeObject(content);

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

        var response = await mut(_fixture.Client, new TokenGetRequest
        {
            Types = new List<string> { type },
            TokenIds = new List<string> { tokenId },
            MetadataQuery = new Dictionary<string, string>() { metadataQuery },
            PageSize = size,
            Page = page
        }, null);

        Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal($"/tokens?page={page}&size={size}&type={type}&id={tokenId}&metadata.{metadataQuery.Key}={metadataQuery.Value}",
            requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetWithPerRequestApiKey(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
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
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tokens", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldGetWithCorrelationId(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
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
        Assert.Equal(HttpMethod.Get, requestMessage.Method);
        Assert.Equal("/tokens", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
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
    public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
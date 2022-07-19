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
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Tokens;

public class DeleteTests : IClassFixture<TokenFixture>
{
    private readonly TokenFixture _fixture;

    public DeleteTests(TokenFixture fixture)
    {
        _fixture = fixture;
    }

    public static IEnumerable<object[]> Methods
    {
        get
        {
            yield return new object[]
            {
                (Func<ITokenClient, string, RequestOptions, Task>) (
                    async (client, tokenId, options) => await client.DeleteAsync(tokenId, options)
                )
            };
            yield return new object[]
            {
                (Func<ITokenClient, string, RequestOptions, Task>) (
                    async (client, tokenId, options) => await client.DeleteAsync(tokenId.ToString(), options)
                )
            };
            yield return new object[]
            {
                (Func<ITokenClient, string, RequestOptions, Task>) (
                    (client, tokenId, options) => Task.Run(() => client.Delete(tokenId, options))
                )
            };
            yield return new object[]
            {
                (Func<ITokenClient, string, RequestOptions, Task>) (
                    (client, tokenId, options) => Task.Run(() => client.Delete(tokenId.ToString(), options))
                )
            };
        }
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDelete(Func<ITokenClient, string, RequestOptions, Task> mut)
    {
        var tokenId = Guid.NewGuid().ToString();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

        await mut(_fixture.Client, tokenId, null);

        Assert.Equal(HttpMethod.Delete, requestMessage.Method);
        Assert.Equal($"/tokens/{tokenId}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteWithPerRequestApiKey(Func<ITokenClient, string, RequestOptions, Task> mut)
    {
        var expectedApiKey = Guid.NewGuid().ToString();

        var tokenId = Guid.NewGuid().ToString();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.Created, null, (message, _) => requestMessage = message);

        await mut(_fixture.Client, tokenId, new RequestOptions
        {
            ApiKey = expectedApiKey
        });

        Assert.Equal(HttpMethod.Delete, requestMessage.Method);
        Assert.Equal($"/tokens/{tokenId}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldDeleteWithCorrelationId(Func<ITokenClient, string, RequestOptions, Task> mut)
    {
        var expectedCorrelationId = Guid.NewGuid().ToString();

        var tokenId = Guid.NewGuid().ToString();

        HttpRequestMessage requestMessage = null;
        _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

        await mut(_fixture.Client, tokenId, new RequestOptions
        {
            CorrelationId = expectedCorrelationId
        });

        Assert.Equal(HttpMethod.Delete, requestMessage.Method);
        Assert.Equal($"/tokens/{tokenId}", requestMessage.RequestUri?.PathAndQuery);
        Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        _fixture.AssertUserAgent(requestMessage);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, string, RequestOptions, Task> mut)
    {
        var error = BasisTheoryErrorFactory.BasisTheoryError();
        var expectedSerializedError = JsonConvert.SerializeObject(error);

        _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

        var exception =
            await Assert.ThrowsAsync<BasisTheoryException>(() =>
                mut(_fixture.Client, Guid.NewGuid().ToString(), null));
        var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

        Assert.Equal(expectedSerializedError, actualSerializedError);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, string, RequestOptions, Task> mut)
    {
        _fixture.SetupHandler(HttpStatusCode.Forbidden);

        var exception =
            await Assert.ThrowsAsync<BasisTheoryException>(() =>
                mut(_fixture.Client, Guid.NewGuid().ToString(), null));

        Assert.Equal(403, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }

    [Theory]
    [MemberData(nameof(Methods))]
    public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, string, RequestOptions, Task> mut)
    {
        var error = Guid.NewGuid().ToString();

        _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

        var exception =
            await Assert.ThrowsAsync<BasisTheoryException>(() =>
                mut(_fixture.Client, Guid.NewGuid().ToString(), null));

        Assert.Equal(500, exception.Error.Status);
        Assert.Null(exception.Error.Title);
        Assert.Null(exception.Error.Detail);
    }
}
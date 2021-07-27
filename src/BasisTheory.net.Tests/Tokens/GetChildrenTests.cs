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
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Tokens
{
    public class GetChildrenTests : IClassFixture<TokenFixture>
    {
        readonly TokenFixture fixture;

        public GetChildrenTests(TokenFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>)(
                        async (client, parentTokenId, request, options) => await client.GetChildrenAsync(parentTokenId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>)(
                        async (client, parentTokenId, request, options) => await client.GetChildrenAsync(parentTokenId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>)(
                        (client, parentTokenId, request, options) => Task.FromResult(client.GetChildren(parentTokenId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>)(
                        (client, parentTokenId, request, options) => Task.FromResult(client.GetChildren(parentTokenId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokens(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensByType(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var type1 = Guid.NewGuid().ToString();
            var type2 = Guid.NewGuid().ToString();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, new TokenGetRequest
            {
                Types = new List<string> { type1, type2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children?type={type1}&type={type2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithChildren(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, new TokenGetRequest
            {
                Children = true
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children?children=true", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithChildrenByType(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var childType1 = Guid.NewGuid().ToString();
            var childType2 = Guid.NewGuid().ToString();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, new TokenGetRequest
            {
                ChildrenTypes = new List<string> { childType1, childType2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children?children_type={childType1}&children_type={childType2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensByIds(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var tokenId1 = Guid.NewGuid();
            var tokenId2 = Guid.NewGuid();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, new TokenGetRequest
            {
                TokenIds = new List<Guid> { tokenId1, tokenId2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children?id={tokenId1}&id={tokenId2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithPagination(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var random = new Randomizer();
            var size = random.Int(1, 20);
            var page = random.Int(1, 20);

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, new TokenGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithAllParameters(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var random = new Randomizer();
            var type = Guid.NewGuid().ToString();
            var childType = Guid.NewGuid().ToString();
            var tokenId = Guid.NewGuid();
            var size = random.Int(1, 20);
            var page = random.Int(1, 20);

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, new TokenGetRequest
            {
                Types = new List<string> { type },
                Children = true,
                ChildrenTypes = new List<string> { childType },
                TokenIds = new List<Guid> { tokenId },
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children?page={page}&size={size}&type={type}&id={tokenId}&children=true&children_type={childType}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithPerRequestApiKey(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithCorrelationId(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.PaginatedTokens();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, parentTokenId, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => call(fixture.Client, Guid.NewGuid(), null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>> call)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => call(fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, Guid, TokenGetRequest, RequestOptions, Task<PaginatedList<Token>>>call)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => call(fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

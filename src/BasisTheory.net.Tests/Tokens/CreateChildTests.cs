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
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Tokens
{
    public class CreateChildTests : IClassFixture<TokenFixture>
    {
        readonly TokenFixture fixture;

        public CreateChildTests(TokenFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        async (client, parentTokenId, token, options) => await client.CreateChildAsync(parentTokenId, token, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        async (client, parentTokenId, child, options) => await client.CreateChildAsync(parentTokenId.ToString(), child, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        async (client, parentTokenId, child, options) => await client.CreateChildAsync(parentTokenId, child.Data, child.Metadata, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        async (client, parentTokenId, child, options) => await client.CreateChildAsync(parentTokenId.ToString(), child.Data, child.Metadata, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        (client, parentTokenId, child, options) => Task.FromResult(client.CreateChild(parentTokenId, child, options))
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        (client, parentTokenId, child, options) => Task.FromResult(client.CreateChild(parentTokenId.ToString(), child, options))
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        (client, parentTokenId, child, options) => Task.FromResult(client.CreateChild(parentTokenId, child.Data, child.Metadata, options))
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>>)(
                        (client, parentTokenId, child, options) => Task.FromResult(client.CreateChild(parentTokenId.ToString(), child.Data, child.Metadata, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateChildToken(Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>> mut)
        {
            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, parentTokenId, content, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateChildTokenWithPerRequestApiKey(Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, parentTokenId, content, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateChildTokenWithCorrelationId(Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var parentTokenId = Guid.NewGuid();
            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, parentTokenId, content, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/tokens/{parentTokenId}/children", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), new Token(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), new Token(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, Guid, Token, RequestOptions, Task<Token>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), new Token(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using BasisTheory.net.Tokens;
using BasisTheory.net.Tokens.Entities;
using BasisTheory.net.Tokens.Requests;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Tokens
{
    public class GetByIdTests : IClassFixture<TokenFixture>
    {
        readonly TokenFixture fixture;

        public GetByIdTests(TokenFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> GetByIdMethods
        {
            get
            {
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>>)(
                        async (client, tokenId, request, options) => await client.GetByIdAsync(tokenId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>>)(
                        async (client, tokenId, request, options) => await client.GetByIdAsync(tokenId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>>)(
                        (client, tokenId, request, options) => Task.FromResult(client.GetById(tokenId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>>)(
                        (client, tokenId, request, options) => Task.FromResult(client.GetById(tokenId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldGetTokenById(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var token = TokenFactory.Token();
            var expectedSerializedToken = JsonConvert.SerializeObject(token);

            HttpRequestMessage requestMessage = null;
            SetupHandler(HttpStatusCode.OK, expectedSerializedToken, (message, _) => requestMessage = message);

            var responseToken = await getByIdCall(fixture.Client, token.Id, null, null);
            var actualSerializedToken = JsonConvert.SerializeObject(responseToken);

            Assert.Equal(expectedSerializedToken, actualSerializedToken);
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{token.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldGetTokenByIdWithChildren(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var token = TokenFactory.Token();
            var serializedToken = JsonConvert.SerializeObject(token);

            HttpRequestMessage requestMessage = null;
            SetupHandler(HttpStatusCode.OK, serializedToken, (message, _) => requestMessage = message);

            await getByIdCall(fixture.Client, token.Id, new TokenGetByIdRequest
            {
                Children = true
            }, null);

            Assert.Equal($"/tokens/{token.Id}?children=true", requestMessage.RequestUri?.PathAndQuery);
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldGetTokenByIdWithChildrenByType(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var token = TokenFactory.Token();
            var childType = Guid.NewGuid().ToString();
            var expectedSerializedToken = JsonConvert.SerializeObject(token);

            HttpRequestMessage requestMessage = null;
            SetupHandler(HttpStatusCode.OK, expectedSerializedToken, (message, _) => requestMessage = message);

            await getByIdCall(fixture.Client, token.Id, new TokenGetByIdRequest
            {
                ChildrenTypes = new List<string> { childType }
            }, null);

            Assert.Equal($"/tokens/{token.Id}?children_type={childType}", requestMessage.RequestUri?.PathAndQuery);
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldGetTokenByIdWithPerRequestApiKey(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var token = TokenFactory.Token();
            var expectedApiKey = Guid.NewGuid().ToString();
            var expectedSerializedToken = JsonConvert.SerializeObject(token);

            HttpRequestMessage requestMessage = null;
            SetupHandler(HttpStatusCode.OK, expectedSerializedToken, (message, _) => requestMessage = message);

            await getByIdCall(fixture.Client, token.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldGetTokenByIdWithCorrelationId(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var token = TokenFactory.Token();
            var expectedCorrelationId = Guid.NewGuid().ToString();
            var expectedSerializedToken = JsonConvert.SerializeObject(token);

            HttpRequestMessage requestMessage = null;
            SetupHandler(HttpStatusCode.OK, expectedSerializedToken, (message, _) => requestMessage = message);

            await getByIdCall(fixture.Client, token.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var tokenId = Guid.NewGuid();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => getByIdCall(fixture.Client, tokenId, null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldHandleNEmptyErrorResponse(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var tokenId = Guid.NewGuid();

            SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => getByIdCall(fixture.Client, tokenId, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(GetByIdMethods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> getByIdCall)
        {
            var error = Guid.NewGuid().ToString();
            var tokenId = Guid.NewGuid();

            SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => getByIdCall(fixture.Client, tokenId, null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        private void SetupHandler(HttpStatusCode statusCode, string content = null, Action<HttpRequestMessage, CancellationToken> messageHandler = null)
        {
            var httpResponseMessage = string.IsNullOrEmpty(content) ?
                new HttpResponseMessage { StatusCode = statusCode } :
                new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                };

            var returnResult = fixture.MessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            if (messageHandler != null)
                returnResult.Callback(messageHandler);
        }
    }
}

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

namespace BasisTheory.net.Tests.Tokens
{
    public class GetByIdTests : IClassFixture<TokenFixture>
    {
        readonly TokenFixture fixture;

        public GetByIdTests(TokenFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
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
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokenById(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, content.Id, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokenByIdWithChildren(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, content.Id, new TokenGetByIdRequest
            {
                Children = true
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}?children=true", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokenByIdWithChildrenByType(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            var childType1 = Guid.NewGuid().ToString();
            var childType2 = Guid.NewGuid().ToString();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, content.Id, new TokenGetByIdRequest
            {
                ChildrenTypes = new List<string> { childType1, childType2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}?children_type={childType1}&children_type={childType2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokenByIdWithPerRequestApiKey(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, content.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokenByIdWithCorrelationId(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await call(fixture.Client, content.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => call(fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> call)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => call(fixture.Client,  Guid.NewGuid(), null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

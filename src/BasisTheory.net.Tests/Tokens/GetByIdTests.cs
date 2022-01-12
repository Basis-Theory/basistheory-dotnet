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
        private readonly TokenFixture _fixture;

        public GetByIdTests(TokenFixture fixture)
        {
            _fixture = fixture;
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
        public async Task ShouldGetById(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/tokens/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ITokenClient, Guid, TokenGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

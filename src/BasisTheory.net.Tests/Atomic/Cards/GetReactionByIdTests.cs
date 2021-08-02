using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Atomic.Cards.Helpers;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Cards
{
    public class GetReactionByIdTests : IClassFixture<AtomicCardFixture>
    {
        readonly AtomicCardFixture _fixture;

        public GetReactionByIdTests(AtomicCardFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>>)(
                        async (client, atomicCardId, reactionTokenId, request, options) =>
                            await client.GetReactionByIdAsync(atomicCardId, reactionTokenId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>>)(
                        async (client, atomicCardId, reactionTokenId, request, options) =>
                            await client.GetReactionByIdAsync(atomicCardId.ToString(), reactionTokenId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>>)(
                        (client, atomicCardId, reactionTokenId, request, options) =>
                            Task.FromResult(client.GetReactionById(atomicCardId, reactionTokenId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>>)(
                        (client, atomicCardId, reactionTokenId, request, options) =>
                            Task.FromResult(client.GetReactionById(atomicCardId.ToString(), reactionTokenId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetReactionById(Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var atomicCardId = Guid.NewGuid();
            var reactionTokenId = Guid.NewGuid();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicCardId, reactionTokenId, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{atomicCardId}/reactions/{reactionTokenId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();
            var atomicCardId = Guid.NewGuid();
            var reactionTokenId = Guid.NewGuid();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicCardId, reactionTokenId, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{atomicCardId}/reactions/{reactionTokenId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();
            var atomicCardId = Guid.NewGuid();
            var reactionTokenId = Guid.NewGuid();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicCardId, reactionTokenId, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{atomicCardId}/reactions/{reactionTokenId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), Guid.NewGuid(), null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IAtomicCardClient, Guid, Guid, ReactionGetByIdRequest, RequestOptions, Task<Token>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), Guid.NewGuid(), null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

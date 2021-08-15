using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards;
using BasisTheory.net.Atomic.Cards.Entities;
using BasisTheory.net.Atomic.Cards.Requests;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Atomic.Cards.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Cards
{
    public class GetByIdTests : IClassFixture<AtomicCardFixture>
    {
        readonly AtomicCardFixture _fixture;

        public GetByIdTests(AtomicCardFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>>)(
                        async (client, atomicCardId, request, options) => await client.GetByIdAsync(atomicCardId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>>)(
                        async (client, atomicCardId, request, options) => await client.GetByIdAsync(atomicCardId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>>)(
                        (client, atomicCardId, request, options) => Task.FromResult(client.GetById(atomicCardId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>>)(
                        (client, atomicCardId, request, options) => Task.FromResult(client.GetById(atomicCardId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetById(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id.GetValueOrDefault(), null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdDecrypted(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id.GetValueOrDefault(), new CardGetByIdRequest
            {
                Decrypt = true
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}/decrypt", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id.GetValueOrDefault(), null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id.GetValueOrDefault(), null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IAtomicCardClient, Guid, CardGetByIdRequest, RequestOptions, Task<AtomicCard>> mut)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Atomic.Cards.Helpers;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Reactors.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Cards
{
    public class ReactTests : IClassFixture<AtomicCardFixture>
    {
        private readonly AtomicCardFixture _fixture;

        public ReactTests(AtomicCardFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>)(
                        async (client, atomicCardId, request, options) => await client.ReactAsync(atomicCardId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>)(
                        async (client, atomicCardId, request, options) => await client.ReactAsync(atomicCardId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>)(
                        (client, atomicCardId, request, options) => Task.FromResult(client.React(atomicCardId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>>)(
                        (client, atomicCardId, request, options) => Task.FromResult(client.React(atomicCardId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldReact(Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var atomicCardId = Guid.NewGuid();
            var request = ReactorFactory.ReactRequest();

            var content = ReactorFactory.ReactResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicCardId, request, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{atomicCardId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithPerRequestApiKey(Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();
            var atomicCardId = Guid.NewGuid();
            var request = ReactorFactory.ReactRequest();

            var content = ReactorFactory.ReactResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicCardId, request, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{atomicCardId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithCorrelationId(Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();
            var atomicCardId = Guid.NewGuid();
            var request = ReactorFactory.ReactRequest();

            var content = ReactorFactory.ReactResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicCardId, request, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{atomicCardId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new ReactRequest(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new ReactRequest(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IAtomicCardClient, Guid, ReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new ReactRequest(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

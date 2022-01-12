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
using BasisTheory.net.Common.Utilities;
using BasisTheory.net.Tests.Atomic.Cards.Helpers;
using BasisTheory.net.Tests.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Cards
{
    public class UpdateTests : IClassFixture<AtomicCardFixture>
    {
        private readonly AtomicCardFixture _fixture;
        private readonly UpdateAtomicCardRequest _expectedRequest;
        private readonly string _expectedResponseJson;
        private readonly Guid _expectedAtomicCardId;

        public UpdateTests(AtomicCardFixture fixture)
        {
            _fixture = fixture;
            _expectedRequest = AtomicCardFactory.UpdateAtomicCardRequest();
            _expectedResponseJson = JsonUtility.SerializeObject(AtomicCardFactory.AtomicCard());
            _expectedAtomicCardId = Guid.NewGuid();
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>>)(
                        async (client, id, request, options) =>
                            await client.UpdateAsync(id, request, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>>)(
                        async (client, id, request, options) =>
                            await client.UpdateAsync(id.ToString(), request, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>>)(
                        (client, id, request, options) =>
                            Task.FromResult(client.Update(id, request, options))
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>>)(
                        (client, id, request, options) =>
                            Task.FromResult(client.Update(id.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdate(
            Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, _expectedResponseJson, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, _expectedAtomicCardId, _expectedRequest, null);

            Assert.Equal(_expectedResponseJson, JsonUtility.SerializeObject(response));
            Assert.Equal(JsonUtility.SerializeObject(_expectedRequest), await requestMessage?.Content?.ReadAsStringAsync()!);
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{_expectedAtomicCardId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithPerRequestApiKey(
            Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, _expectedResponseJson, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, _expectedAtomicCardId, _expectedRequest, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(_expectedResponseJson, JsonUtility.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{_expectedAtomicCardId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithCorrelationId(
            Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, _expectedResponseJson, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, _expectedAtomicCardId, _expectedRequest, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(_expectedResponseJson, JsonUtility.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{_expectedAtomicCardId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonUtility.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() =>
                    mut(_fixture.Client, _expectedAtomicCardId, new UpdateAtomicCardRequest(), null));
            var actualSerializedError = JsonUtility.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() =>
                    mut(_fixture.Client, _expectedAtomicCardId, new UpdateAtomicCardRequest(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IAtomicCardClient, Guid, UpdateAtomicCardRequest, RequestOptions, Task<AtomicCard>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() =>
                    mut(_fixture.Client, _expectedAtomicCardId, new UpdateAtomicCardRequest(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

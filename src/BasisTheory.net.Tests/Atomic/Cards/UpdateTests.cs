using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards;
using BasisTheory.net.Atomic.Cards.Entities;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Atomic.Cards.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Cards
{
    public class UpdateTests : IClassFixture<AtomicCardFixture>
    {
        readonly AtomicCardFixture _fixture;

        public UpdateTests(AtomicCardFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>>)(
                        async (client, atomicCard, options) =>
                            await client.UpdateAsync(atomicCard.Id, atomicCard, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>>)(
                        async (client, atomicCard, options) =>
                            await client.UpdateAsync(atomicCard.Id.ToString(), atomicCard, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>>)(
                        (client, atomicCard, options) =>
                            Task.FromResult(client.Update(atomicCard.Id, atomicCard, options))
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>>)(
                        (client, atomicCard, options) =>
                            Task.FromResult(client.Update(atomicCard.Id.ToString(), atomicCard, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdate(Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>> mut)
        {
            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithPerRequestApiKey(
            Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithCorrelationId(
            Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = AtomicCardFactory.AtomicCard();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/cards/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new AtomicCard(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new AtomicCard(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IAtomicCardClient, AtomicCard, RequestOptions, Task<AtomicCard>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new AtomicCard(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

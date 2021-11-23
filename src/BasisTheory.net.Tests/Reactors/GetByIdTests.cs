using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Reactors;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Reactors.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Reactors
{
    public class GetByIdTests : IClassFixture<ReactorFixture>
    {
        private readonly ReactorFixture _fixture;

        public GetByIdTests(ReactorFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>>)(
                        async (client, reactorId, request, options) =>
                            await client.GetByIdAsync(reactorId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>>)(
                        async (client, reactorId, request, options) =>
                            await client.GetByIdAsync(reactorId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>>)(
                        (client, reactorId, request, options) =>
                            Task.FromResult(client.GetById(reactorId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>>)(
                        (client, reactorId, request, options) =>
                            Task.FromResult(client.GetById(reactorId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetById(Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>> mut)
        {
            var content = ReactorFactory.Reactor();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ReactorFactory.Reactor();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ReactorFactory.Reactor();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IReactorClient, Guid, ReactorGetByIdRequest, RequestOptions, Task<Reactor>> mut)
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

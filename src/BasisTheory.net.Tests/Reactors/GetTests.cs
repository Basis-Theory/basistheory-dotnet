using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Reactors.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Reactors
{
    public class GetTests : IClassFixture<ReactorFixture>
    {
        private readonly ReactorFixture _fixture;

        public GetTests(ReactorFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>>)(
                        (client, request, options) =>  Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/reactors", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIds(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var reactorId1 = Guid.NewGuid();
            var reactorId2 = Guid.NewGuid();

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorGetRequest
            {
                ReactorIds = new List<Guid> { reactorId1, reactorId2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors?id={reactorId1}&id={reactorId2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByName(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var name = _fixture.Faker.Lorem.Word();

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorGetRequest
            {
                Name = name
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors?name={name}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetBySourceTokenType(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var sourceTokenType = _fixture.Faker.Lorem.Word();

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorGetRequest
            {
                SourceTokenType = sourceTokenType
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors?source_token_type={sourceTokenType}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPagination(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var size = _fixture.Faker.Random.Int(1, 20);
            var page = _fixture.Faker.Random.Int(1, 20);

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithAllParameters(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var reactorId = Guid.NewGuid();
            var name = _fixture.Faker.Lorem.Word();
            var sourceTokenType = _fixture.Faker.Lorem.Word();
            var size = _fixture.Faker.Random.Int(1, 20);
            var page = _fixture.Faker.Random.Int(1, 20);

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorGetRequest
            {
                ReactorIds = new List<Guid> { reactorId },
                Name = name,
                SourceTokenType = sourceTokenType,
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactors?page={page}&size={size}&id={reactorId}&name={name}&source_token_type={sourceTokenType}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/reactors", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ReactorFactory.PaginatedReactors();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/reactors", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IReactorClient, ReactorGetRequest, RequestOptions, Task<PaginatedList<Reactor>>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

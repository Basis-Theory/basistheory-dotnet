using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Exchanges;
using BasisTheory.net.Exchanges.Entities;
using BasisTheory.net.Exchanges.Requests;
using BasisTheory.net.Tests.Exchanges.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Exchanges
{
    public class GetTests : IClassFixture<ExchangeFixture>
    {
        readonly ExchangeFixture fixture;

        public GetTests(ExchangeFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>>)(
                        (client, request, options) =>  Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/exchanges", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIds(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var exchangeId1 = Guid.NewGuid();
            var exchangeId2 = Guid.NewGuid();

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeGetRequest
            {
                ExchangeIds = new List<Guid> { exchangeId1, exchangeId2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges?id={exchangeId1}&id={exchangeId2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByName(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var name = fixture.Faker.Lorem.Word();

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeGetRequest
            {
                Name = name
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges?name={name}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetBySourceTokenType(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var sourceTokenType = fixture.Faker.Lorem.Word();

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeGetRequest
            {
                SourceTokenType = sourceTokenType
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges?source_token_type={sourceTokenType}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPagination(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var size = fixture.Faker.Random.Int(1, 20);
            var page = fixture.Faker.Random.Int(1, 20);

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithAllParameters(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var exchangeId = Guid.NewGuid();
            var name = fixture.Faker.Lorem.Word();
            var sourceTokenType = fixture.Faker.Lorem.Word();
            var size = fixture.Faker.Random.Int(1, 20);
            var page = fixture.Faker.Random.Int(1, 20);

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeGetRequest
            {
                ExchangeIds = new List<Guid> { exchangeId },
                Name = name,
                SourceTokenType = sourceTokenType,
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges?page={page}&size={size}&id={exchangeId}&name={name}&source_token_type={sourceTokenType}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/exchanges", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ExchangeFactory.PaginatedExchanges();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/exchanges", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IExchangeClient, ExchangeGetRequest, RequestOptions, Task<PaginatedList<Exchange>>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Logs;
using BasisTheory.net.Logs.Entities;
using BasisTheory.net.Logs.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Logs.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Logs
{
    public class GetTests : IClassFixture<LogFixture>
    {
        readonly LogFixture fixture;

        public GetTests(LogFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>>)(
                        (client, request, options) => Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokens(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/logs", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetLogsByEntityType(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var entityType = fixture.Faker.Lorem.Word();

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new LogGetRequest
            {
                EntityType = entityType
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/logs?entity_type={entityType}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetLogsByEntityId(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var entityId = fixture.Faker.Lorem.Word();

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new LogGetRequest
            {
                EntityId = entityId
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/logs?entity_id={entityId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetLogsAfterStartDate(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var startDate = fixture.Faker.Date.PastOffset();

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new LogGetRequest
            {
                StartDate = startDate
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/logs?start_date={startDate:s}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetLogsBeforeEndDate(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var endDate = fixture.Faker.Date.FutureOffset();

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new LogGetRequest
            {
                EndDate = endDate
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/logs?end_date={endDate:s}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetLogsWithPagination(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var size = fixture.Faker.Random.Int(1, 20);
            var page = fixture.Faker.Random.Int(1, 20);

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new LogGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/logs?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetLogsWithAllParameters(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var entityType = fixture.Faker.Lorem.Word();
            var entityId = fixture.Faker.Lorem.Word();
            var startDate = fixture.Faker.Date.PastOffset();
            var endDate = fixture.Faker.Date.FutureOffset();
            var size = fixture.Faker.Random.Int(1, 20);
            var page = fixture.Faker.Random.Int(1, 20);

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new LogGetRequest
            {
                EntityType = entityType,
                EntityId = entityId,
                StartDate = startDate,
                EndDate = endDate,
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/logs?page={page}&size={size}&entity_type={entityType}&entity_id={entityId}&start_date={startDate:s}&end_date={endDate:s}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithPerRequestApiKey(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/logs", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetTokensWithCorrelationId(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = LogFactory.PaginatedLogs();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/logs", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<ILogClient, LogGetRequest, RequestOptions, Task<PaginatedList<Log>>> mut)
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

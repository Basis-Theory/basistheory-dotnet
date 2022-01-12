using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Applications;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.Applications.Requests;
using BasisTheory.net.Tests.Applications.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Applications
{
    public class GetTests : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixture;

        public GetTests(ApplicationFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>>)(
                        (client, request, options) =>  Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
        {
            var content = ApplicationFactory.PaginatedApplications();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/applications", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIds(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
        {
            var applicationId1 = Guid.NewGuid();
            var applicationId2 = Guid.NewGuid();

            var content = ApplicationFactory.PaginatedApplications();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ApplicationGetRequest
            {
                ApplicationIds = new List<Guid> { applicationId1, applicationId2 }
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications?id={applicationId1}&id={applicationId2}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPagination(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
        {
            var size = _fixture.Faker.Random.Int(1, 20);
            var page = _fixture.Faker.Random.Int(1, 20);

            var content = ApplicationFactory.PaginatedApplications();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ApplicationGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithAllParameters(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
        {
            var applicationId = Guid.NewGuid();
            var size = _fixture.Faker.Random.Int(1, 20);
            var page = _fixture.Faker.Random.Int(1, 20);

            var content = ApplicationFactory.PaginatedApplications();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ApplicationGetRequest
            {
                ApplicationIds = new List<Guid> { applicationId },
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications?page={page}&size={size}&id={applicationId}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ApplicationFactory.PaginatedApplications();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/applications", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ApplicationFactory.PaginatedApplications();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/applications", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
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
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
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
            Func<IApplicationClient, ApplicationGetRequest, RequestOptions, Task<PaginatedList<Application>>> mut)
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

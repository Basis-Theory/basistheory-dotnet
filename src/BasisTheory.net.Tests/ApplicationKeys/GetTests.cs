using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.ApplicationKeys;
using BasisTheory.net.ApplicationKeys.Entities;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Applications;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.Applications.Requests;
using BasisTheory.net.Tests.ApplicationKeys.Helpers;
using BasisTheory.net.Tests.Applications.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ApplicationKeys
{
    public class GetTests : IClassFixture<ApplicationKeysFixture>
    {
        private readonly ApplicationKeysFixture _fixture;

        public GetTests(ApplicationKeysFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>>)(
                        async (client, applicationId, options) => await client.GetAsync(applicationId, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>>)(
                        (client, applicationId, options) =>  Task.FromResult(client.Get(applicationId, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(
            Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>> mut)
        {
            var content = ApplicationKeyFactory.ApplicationKeys();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            var applicationId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, applicationId, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}/keys", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(
            Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ApplicationKeyFactory.ApplicationKeys();
            var expectedSerialized = JsonConvert.SerializeObject(content);


            var applicationId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, applicationId, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}/keys", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(
            Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ApplicationKeyFactory.ApplicationKeys();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            var applicationId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, applicationId, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}/keys", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            var applicationId = Guid.NewGuid();

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, applicationId, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);
            var applicationId = Guid.NewGuid();
            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, applicationId, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorRespons(
            Func<IApplicationKeysClient, Guid, RequestOptions, Task<List<ApplicationKey>>> mut)
        {
            var error = Guid.NewGuid().ToString();

            var applicationId = Guid.NewGuid();
            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, applicationId, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

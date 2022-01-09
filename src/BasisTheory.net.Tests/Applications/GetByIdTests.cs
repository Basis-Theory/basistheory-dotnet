using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Applications;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.Applications.Requests;
using BasisTheory.net.Tests.Applications.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Applications
{
    public class GetByIdTests : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixture;

        public GetByIdTests(ApplicationFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>>)(
                        async (client, applicationId, request, options) =>
                            await client.GetByIdAsync(applicationId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>>)(
                        async (client, applicationId, request, options) =>
                            await client.GetByIdAsync(applicationId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>>)(
                        (client, applicationId, request, options) =>
                            Task.FromResult(client.GetById(applicationId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>>)(
                        (client, applicationId, request, options) =>
                            Task.FromResult(client.GetById(applicationId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetById(Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>> mut)
        {
            var content = ApplicationFactory.Application();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ApplicationFactory.Application();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ApplicationFactory.Application();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IApplicationClient, Guid, ApplicationGetByIdRequest, RequestOptions, Task<Application>> mut)
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

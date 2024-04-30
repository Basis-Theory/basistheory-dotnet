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
using BasisTheory.net.Tests.ApplicationKeys.Helpers;
using BasisTheory.net.Tests.Applications.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ApplicationKeys
{
    public class GetByIdTests : IClassFixture<ApplicationKeysFixture>
    {
        private readonly ApplicationKeysFixture _fixture;

        public GetByIdTests(ApplicationKeysFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IApplicationKeysClient, Guid,Guid, RequestOptions, Task<ApplicationKey>>)(
                        async (client, applicationId,keyId, options) =>
                            await client.GetByIdAsync(applicationId,keyId, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IApplicationKeysClient, Guid,Guid, RequestOptions, Task<ApplicationKey>>)(
                        (client, applicationId,keyId, options) =>
                            Task.FromResult(client.GetById(applicationId,keyId, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetById(Func<IApplicationKeysClient, Guid, Guid, RequestOptions, Task<ApplicationKey>> mut)
        {
            var content = ApplicationKeyFactory.ApplicationKey();
            var expectedSerialized = JsonConvert.SerializeObject(content);


            var applicationId = Guid.NewGuid();
            var keyId = content.Id;

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, applicationId, keyId, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}/keys/{keyId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IApplicationKeysClient, Guid, Guid, RequestOptions, Task<ApplicationKey>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ApplicationKeyFactory.ApplicationKey();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            var applicationId = Guid.NewGuid();
            var keyId = content.Id;

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, applicationId, keyId, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}/keys/{keyId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IApplicationKeysClient, Guid, Guid, RequestOptions, Task<ApplicationKey>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ApplicationKeyFactory.ApplicationKey();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            var applicationId = Guid.NewGuid();
            var keyId = content.Id;


            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, applicationId, keyId, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}/keys/{keyId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IApplicationKeysClient, Guid, Guid, RequestOptions, Task<ApplicationKey>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), Guid.NewGuid(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IApplicationKeysClient, Guid, Guid, RequestOptions, Task<ApplicationKey>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), Guid.NewGuid(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IApplicationKeysClient, Guid, Guid, RequestOptions, Task<ApplicationKey>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), Guid.NewGuid(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

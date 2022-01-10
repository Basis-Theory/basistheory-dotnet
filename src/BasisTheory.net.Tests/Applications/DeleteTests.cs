using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Applications;
using BasisTheory.net.Tests.Applications.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Applications
{
    public class DeleteTests : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixture;

        public DeleteTests(ApplicationFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, RequestOptions, Task>)(
                        async (client, applicationId, options) => await client.DeleteAsync(applicationId, options)
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, RequestOptions, Task>)(
                        async (client, applicationId, options) => await client.DeleteAsync(applicationId.ToString(), options)
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, RequestOptions, Task>)(
                        (client, applicationId, options) => Task.Run(() => client.Delete(applicationId, options))
                    )
                };
                yield return new object []
                {
                    (Func<IApplicationClient, Guid, RequestOptions, Task>)(
                        (client, applicationId, options) => Task.Run(() => client.Delete(applicationId.ToString(), options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDelete(Func<IApplicationClient, Guid, RequestOptions, Task> mut)
        {
            var applicationId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, applicationId, null);

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithPerRequestApiKey(Func<IApplicationClient, Guid, RequestOptions, Task> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var applicationId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, applicationId, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithCorrelationId(Func<IApplicationClient, Guid, RequestOptions, Task> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var applicationId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, applicationId, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/applications/{applicationId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IApplicationClient, Guid, RequestOptions, Task> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IApplicationClient, Guid, RequestOptions, Task> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IApplicationClient, Guid, RequestOptions, Task> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

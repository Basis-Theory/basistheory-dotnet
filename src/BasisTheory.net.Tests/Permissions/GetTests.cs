using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Permissions;
using BasisTheory.net.Permissions.Entities;
using BasisTheory.net.Permissions.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Permissions.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Permissions
{
    public class GetTests : IClassFixture<PermissionFixture>
    {
        private readonly PermissionFixture _fixture;

        public GetTests(PermissionFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>>)(
                        (client, request, options) => Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
        {
            var content = PermissionFactory.PermissionList();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/permissions", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByApplicationType(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
        {
            var applicationType = Guid.NewGuid().ToString();

            var content = PermissionFactory.PermissionList();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new PermissionGetRequest
            {
                ApplicationType = applicationType
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/permissions?application_type={applicationType}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = PermissionFactory.PermissionList();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/permissions", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = PermissionFactory.PermissionList();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/permissions", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IPermissionClient, PermissionGetRequest, RequestOptions, Task<List<Permission>>> mut)
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

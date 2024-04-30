using Xunit;
using BasisTheory.net.Tests.ThreeDS.Helpers;
using System.Collections.Generic;
using System;
using BasisTheory.net.ThreeDS;
using BasisTheory.net.Common.Requests;
using System.Threading.Tasks;
using BasisTheory.net.ThreeDS.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Common.Errors;
using System.Net;
using BasisTheory.net.ThreeDS.Requests;

namespace BasisTheory.net.Tests.ThreeDS
{
    public class AuthenticateTests : IClassFixture<ThreeDSFixture>
    {
        private readonly ThreeDSFixture _fixture;

        public AuthenticateTests(ThreeDSFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
          (Func<IThreeDSClient, string, AuthenticateThreeDSSessionRequest, RequestOptions, Task<ThreeDSAuthentication>>) (
            async (client, sessionId, request, options) => await client.AuthenticateThreeDSSessionAsync(sessionId, request, options)
          )
                };
                yield return new object[]
                {
          (Func<IThreeDSClient, string, AuthenticateThreeDSSessionRequest, RequestOptions, Task<ThreeDSAuthentication>>) (
            (client, sessionId, request, options) => Task.FromResult(client.AuthenticateThreeDSSession(sessionId, request, options))
          )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldAuthenticate(Func<IThreeDSClient, string, AuthenticateThreeDSSessionRequest, RequestOptions, Task<ThreeDSAuthentication>> mut)
        {
            var sessionId = Guid.NewGuid();
            var request = ThreeDSFactory.AuthenticateThreeDSSessionRequest();
            var authentication = ThreeDSFactory.ThreeDSAuthentication();
            var expectedSerializedRequest = JsonConvert.SerializeObject(request);
            var expectedSerializedResponse = JsonConvert.SerializeObject(authentication);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(System.Net.HttpStatusCode.OK, expectedSerializedResponse, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, sessionId.ToString(), request, null);

            Assert.Equal(expectedSerializedResponse, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/3ds/sessions/{sessionId}/authenticate", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
        Func<IThreeDSClient, string, AuthenticateThreeDSSessionRequest, RequestOptions, Task<ThreeDSAuthentication>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid().ToString(), new AuthenticateThreeDSSessionRequest(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IThreeDSClient, string, AuthenticateThreeDSSessionRequest, RequestOptions, Task<ThreeDSAuthentication>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid().ToString(), new AuthenticateThreeDSSessionRequest(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IThreeDSClient, string, AuthenticateThreeDSSessionRequest, RequestOptions, Task<ThreeDSAuthentication>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid().ToString(), new AuthenticateThreeDSSessionRequest(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}
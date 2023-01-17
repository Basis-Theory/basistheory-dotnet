using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Sessions;
using BasisTheory.net.Tests.Sessions.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Sessions
{
    public class AuthorizeTests : IClassFixture<SessionFixture>
    {
        private readonly SessionFixture _fixture;
        
        public AuthorizeTests(SessionFixture fixture)
        {
            _fixture = fixture;
        }
        
        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<ISessionClient, AuthorizeSessionRequest, RequestOptions, Task>)(
                        async (client, request, options) => await client.AuthorizeAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<ISessionClient, AuthorizeSessionRequest, RequestOptions, Task>)(
                        (client, request, options) => Task.Run(() => client.Authorize(request, options))
                    )
                };
            }
        }
        
        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldAuthorize(Func<ISessionClient, AuthorizeSessionRequest, RequestOptions, Task> mut)
        {
            var request = new AuthorizeSessionRequest();
            
            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, request, null);
            
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/sessions/authorize", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }
    }
}
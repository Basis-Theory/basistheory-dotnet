using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Sessions;
using BasisTheory.net.Tests.Sessions.Helpers;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Sessions
{
    public class CreateTests : IClassFixture<SessionFixture>
    {
        private readonly SessionFixture _fixture;
        
        public CreateTests(SessionFixture fixture)
        {
            _fixture = fixture;
        }
        
        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<ISessionClient, RequestOptions, Task<CreateSessionResponse>>)(
                        async (client, options) => await client.CreateAsync(options)
                    )
                };
                yield return new object []
                {
                    (Func<ISessionClient, RequestOptions, Task<CreateSessionResponse>>)(
                        (client, options) => Task.FromResult(client.Create(options))
                    )
                };
            }
        }
        
        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreate(Func<ISessionClient, RequestOptions, Task<CreateSessionResponse>> mut)
        {
            var content = new CreateSessionResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);
            
            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/sessions", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Atomic.Banks.Helpers;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Reactors.Helpers;
using BasisTheory.net.Tests.Tokens.Helpers;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Banks
{
    public class ReactTests : IClassFixture<AtomicBankFixture>
    {
        readonly AtomicBankFixture fixture;

        public ReactTests(AtomicBankFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>>)(
                        async (client, atomicBankId, request, options) => await client.ReactAsync(atomicBankId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>>)(
                        async (client, atomicBankId, request, options) => await client.ReactAsync(atomicBankId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>>)(
                        (client, atomicBankId, request, options) => Task.FromResult(client.React(atomicBankId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>>)(
                        (client, atomicBankId, request, options) => Task.FromResult(client.React(atomicBankId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldReact(Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>> mut)
        {
            var atomicBankId = Guid.NewGuid();
            var request = ReactorFactory.ReactRequest();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, atomicBankId, request, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithPerRequestApiKey(Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();
            var atomicBankId = Guid.NewGuid();
            var request = ReactorFactory.ReactRequest();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, atomicBankId, request, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithCorrelationId(Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();
            var atomicBankId = Guid.NewGuid();
            var request = ReactorFactory.ReactRequest();

            var content = TokenFactory.Token();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, atomicBankId, request, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), new ReactRequest(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), new ReactRequest(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IAtomicBankClient, Guid, ReactRequest, RequestOptions, Task<Token>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), new ReactRequest(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

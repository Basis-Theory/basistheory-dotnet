using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tests.Atomic.Banks.Helpers;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.Reactors.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Banks
{
    public class ReactTests : IClassFixture<AtomicBankFixture>
    {
        private readonly AtomicBankFixture _fixture;

        public ReactTests(AtomicBankFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>>)(
                        async (client, atomicBankId, request, options) => await client.ReactAsync(atomicBankId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>>)(
                        async (client, atomicBankId, request, options) => await client.ReactAsync(atomicBankId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>>)(
                        (client, atomicBankId, request, options) => Task.FromResult(client.React(atomicBankId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>>)(
                        (client, atomicBankId, request, options) => Task.FromResult(client.React(atomicBankId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldReact(Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var atomicBankId = Guid.NewGuid();
            var request = ReactorFactory.AtomicReactRequest();

            var content = ReactorFactory.ReactResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicBankId, request, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithPerRequestApiKey(Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();
            var atomicBankId = Guid.NewGuid();
            var request = ReactorFactory.AtomicReactRequest();

            var content = ReactorFactory.ReactResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicBankId, request, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithCorrelationId(Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();
            var atomicBankId = Guid.NewGuid();
            var request = ReactorFactory.AtomicReactRequest();

            var content = ReactorFactory.ReactResponse();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, atomicBankId, request, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}/react", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new AtomicReactRequest(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new AtomicReactRequest(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IAtomicBankClient, Guid, AtomicReactRequest, RequestOptions, Task<ReactResponse>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), new AtomicReactRequest(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

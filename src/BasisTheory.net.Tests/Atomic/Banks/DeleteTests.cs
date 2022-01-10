using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Atomic.Banks.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Banks
{
    public class DeleteTests : IClassFixture<AtomicBankFixture>
    {
        private readonly AtomicBankFixture _fixture;

        public DeleteTests(AtomicBankFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, RequestOptions, Task>)(
                        async (client, atomicBankId, options) => await client.DeleteAsync(atomicBankId, options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, RequestOptions, Task>)(
                        async (client, atomicBankId, options) => await client.DeleteAsync(atomicBankId.ToString(), options)
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, RequestOptions, Task>)(
                        (client, atomicBankId, options) => Task.Run(() => client.Delete(atomicBankId, options))
                    )
                };
                yield return new object []
                {
                    (Func<IAtomicBankClient, Guid, RequestOptions, Task>)(
                        (client, atomicBankId, options) => Task.Run(() => client.Delete(atomicBankId.ToString(), options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDelete(Func<IAtomicBankClient, Guid, RequestOptions, Task> mut)
        {
            var atomicBankId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, atomicBankId, null);

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithPerRequestApiKey(Func<IAtomicBankClient, Guid, RequestOptions, Task> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var atomicBankId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, atomicBankId, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithCorrelationId(Func<IAtomicBankClient, Guid, RequestOptions, Task> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var atomicBankId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, atomicBankId, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{atomicBankId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IAtomicBankClient, Guid, RequestOptions, Task> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<IAtomicBankClient, Guid, RequestOptions, Task> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IAtomicBankClient, Guid, RequestOptions, Task> mut)
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

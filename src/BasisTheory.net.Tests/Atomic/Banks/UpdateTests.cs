using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks;
using BasisTheory.net.Atomic.Banks.Entities;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tests.Atomic.Banks.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Banks
{
    public class UpdateTests : IClassFixture<AtomicBankFixture>
    {
        readonly AtomicBankFixture _fixture;

        public UpdateTests(AtomicBankFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>>)(
                        async (client, atomicBank, options) =>
                            await client.UpdateAsync(atomicBank.Id, atomicBank, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>>)(
                        async (client, atomicBank, options) =>
                            await client.UpdateAsync(atomicBank.Id.ToString(), atomicBank, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>>)(
                        (client, atomicBank, options) =>
                            Task.FromResult(client.Update(atomicBank.Id, atomicBank, options))
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>>)(
                        (client, atomicBank, options) =>
                            Task.FromResult(client.Update(atomicBank.Id.ToString(), atomicBank, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdate(Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>> mut)
        {
            var content = AtomicBankFactory.AtomicBank();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithPerRequestApiKey(
            Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = AtomicBankFactory.AtomicBank();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithCorrelationId(
            Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = AtomicBankFactory.AtomicBank();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new AtomicBank(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new AtomicBank(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IAtomicBankClient, AtomicBank, RequestOptions, Task<AtomicBank>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new AtomicBank(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

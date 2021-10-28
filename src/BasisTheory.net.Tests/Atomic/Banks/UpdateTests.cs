using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks;
using BasisTheory.net.Atomic.Banks.Entities;
using BasisTheory.net.Atomic.Banks.Requests;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Utilities;
using BasisTheory.net.Tests.Atomic.Banks.Helpers;
using BasisTheory.net.Tests.Helpers;
using Xunit;

namespace BasisTheory.net.Tests.Atomic.Banks
{
    public class UpdateTests : IClassFixture<AtomicBankFixture>
    {
        private readonly AtomicBankFixture _fixture;
        private readonly UpdateAtomicBankRequest _expectedRequest;
        private readonly string _expectedResponseJson;
        private readonly Guid _expectedAtomicBankId;

        public UpdateTests(AtomicBankFixture fixture)
        {
            _fixture = fixture;
            _expectedRequest = new UpdateAtomicBankRequest { Bank = AtomicBankFactory.Bank() };
            _expectedResponseJson = JsonUtility.SerializeObject(AtomicBankFactory.AtomicBank());
            _expectedAtomicBankId = Guid.NewGuid();
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>>)(
                        async (client, id, request, options) =>
                            await client.UpdateAsync(id, request, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>>)(
                        async (client, id, request, options) =>
                            await client.UpdateAsync(id.ToString(), request, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>>)(
                        (client, id, request, options) =>
                            Task.FromResult(client.Update(id, request, options))
                    )
                };
                yield return new object[]
                {
                    (Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>>)(
                        (client, id, request, options) =>
                            Task.FromResult(client.Update(id.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdate(Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>> mut)
        {
            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, _expectedResponseJson, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, _expectedAtomicBankId, _expectedRequest, null);

            Assert.Equal(_expectedResponseJson, JsonUtility.SerializeObject(response));
            Assert.Equal(JsonUtility.SerializeObject(_expectedRequest), await requestMessage?.Content?.ReadAsStringAsync()!);
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{_expectedAtomicBankId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithPerRequestApiKey(
            Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, _expectedResponseJson, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, _expectedAtomicBankId, _expectedRequest, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(_expectedResponseJson, JsonUtility.SerializeObject(response));
            Assert.Equal(JsonUtility.SerializeObject(_expectedRequest), await requestMessage?.Content?.ReadAsStringAsync()!);
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{_expectedAtomicBankId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithCorrelationId(
            Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, _expectedResponseJson, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, _expectedAtomicBankId, _expectedRequest, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(_expectedResponseJson, JsonUtility.SerializeObject(response));
            Assert.Equal(JsonUtility.SerializeObject(_expectedRequest), await requestMessage?.Content?.ReadAsStringAsync()!);
            Assert.Equal(HttpMethod.Patch, requestMessage.Method);
            Assert.Equal($"/atomic/banks/{_expectedAtomicBankId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonUtility.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, _expectedAtomicBankId, new UpdateAtomicBankRequest(), null));
            var actualSerializedError = JsonUtility.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, _expectedAtomicBankId, new UpdateAtomicBankRequest(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IAtomicBankClient, Guid, UpdateAtomicBankRequest, RequestOptions, Task<AtomicBank>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception =
                await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, _expectedAtomicBankId, new UpdateAtomicBankRequest(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

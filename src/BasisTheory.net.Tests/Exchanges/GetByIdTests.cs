using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Exchanges;
using BasisTheory.net.Exchanges.Entities;
using BasisTheory.net.Exchanges.Requests;
using BasisTheory.net.Tests.Exchanges.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Exchanges
{
    public class GetByIdTests : IClassFixture<ExchangeFixture>
    {
        readonly ExchangeFixture fixture;

        public GetByIdTests(ExchangeFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>>)(
                        async (client, exchangeId, request, options) =>
                            await client.GetByIdAsync(exchangeId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>>)(
                        async (client, exchangeId, request, options) =>
                            await client.GetByIdAsync(exchangeId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>>)(
                        (client, exchangeId, request, options) =>
                            Task.FromResult(client.GetById(exchangeId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>>)(
                        (client, exchangeId, request, options) =>
                            Task.FromResult(client.GetById(exchangeId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetById(Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>> mut)
        {
            var content = ExchangeFactory.Exchange();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content.Id, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ExchangeFactory.Exchange();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ExchangeFactory.Exchange();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchanges/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IExchangeClient, Guid, ExchangeGetByIdRequest, RequestOptions, Task<Exchange>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

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
using BasisTheory.net.Tests.Exchanges.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Exchanges
{
    public class UpdateTests : IClassFixture<ExchangeFixture>
    {
        readonly ExchangeFixture fixture;

        public UpdateTests(ExchangeFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>>)(
                        async (client, exchange, options) => await client.UpdateAsync(exchange.Id, exchange, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>>)(
                        async (client, exchange, options) => await client.UpdateAsync(exchange.Id.ToString(), exchange, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>>)(
                        (client, exchange, options) => Task.FromResult(client.Update(exchange.Id, exchange, options))
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>>)(
                        (client, exchange, options) => Task.FromResult(client.Update(exchange.Id.ToString(), exchange, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdate(Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>> mut)
        {
            var content = ExchangeFactory.Exchange();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Put, requestMessage.Method);
            Assert.Equal($"/exchanges/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithPerRequestApiKey(Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ExchangeFactory.Exchange();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Put, requestMessage.Method);
            Assert.Equal($"/exchanges/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldUpdateWithCorrelationId(Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ExchangeFactory.Exchange();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Put, requestMessage.Method);
            Assert.Equal($"/exchanges/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, new Exchange(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, new Exchange(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IExchangeClient, Exchange, RequestOptions, Task<Exchange>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, new Exchange(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

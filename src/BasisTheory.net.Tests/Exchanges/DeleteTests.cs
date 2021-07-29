using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Exchanges;
using BasisTheory.net.Tests.Exchanges.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.Exchanges
{
    public class DeleteTests : IClassFixture<ExchangeFixture>
    {
        readonly ExchangeFixture fixture;

        public DeleteTests(ExchangeFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, RequestOptions, Task>)(
                        async (client, exchangeId, options) => await client.DeleteAsync(exchangeId, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, RequestOptions, Task>)(
                        async (client, exchangeId, options) => await client.DeleteAsync(exchangeId.ToString(), options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, RequestOptions, Task>)(
                        (client, exchangeId, options) => Task.Run(() => client.Delete(exchangeId, options))
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeClient, Guid, RequestOptions, Task>)(
                        (client, exchangeId, options) => Task.Run(() => client.Delete(exchangeId.ToString(), options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDelete(Func<IExchangeClient, Guid, RequestOptions, Task> mut)
        {
            var exchangeId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(fixture.Client, exchangeId, null);

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/exchanges/{exchangeId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithPerRequestApiKey(Func<IExchangeClient, Guid, RequestOptions, Task> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var exchangeId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(fixture.Client, exchangeId, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/exchanges/{exchangeId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithCorrelationId(Func<IExchangeClient, Guid, RequestOptions, Task> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var exchangeId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(fixture.Client, exchangeId, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/exchanges/{exchangeId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IExchangeClient, Guid, RequestOptions, Task> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IExchangeClient, Guid, RequestOptions, Task> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IExchangeClient, Guid, RequestOptions, Task> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

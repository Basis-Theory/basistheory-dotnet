using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.ExchangeTemplates;
using BasisTheory.net.ExchangeTemplates.Entities;
using BasisTheory.net.Tests.ExchangeTemplates.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ExchangeTemplates
{
    public class CreateTests : IClassFixture<ExchangeTemplateFixture>
    {
        readonly ExchangeTemplateFixture fixture;

        public CreateTests(ExchangeTemplateFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>>)(
                        async (client, exchangeTemplate, options) => await client.CreateAsync(exchangeTemplate, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>>)(
                        (client, exchangeTemplate, options) => Task.FromResult(client.Create(exchangeTemplate, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreate(Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>> mut)
        {
            var content = ExchangeTemplateFactory.ExchangeTemplate();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/exchange-templates", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithPerRequestApiKey(Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ExchangeTemplateFactory.ExchangeTemplate();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/exchange-templates", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithCorrelationId(Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ExchangeTemplateFactory.ExchangeTemplate();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/exchange-templates", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, new ExchangeTemplate(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, new ExchangeTemplate(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IExchangeTemplateClient, ExchangeTemplate, RequestOptions, Task<ExchangeTemplate>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, new ExchangeTemplate(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

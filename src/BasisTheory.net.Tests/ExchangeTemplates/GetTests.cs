using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.ExchangeTemplates;
using BasisTheory.net.ExchangeTemplates.Entities;
using BasisTheory.net.ExchangeTemplates.Requests;
using BasisTheory.net.Tests.ExchangeTemplates.Helpers;
using BasisTheory.net.Tests.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ExchangeTemplates
{
    public class GetTests : IClassFixture<ExchangeTemplateFixture>
    {
        readonly ExchangeTemplateFixture fixture;

        public GetTests(ExchangeTemplateFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>>)(
                        (client, request, options) =>  Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/exchange-templates", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByName(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var name = fixture.Faker.Lorem.Word();

            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeTemplateGetRequest
            {
                Name = name
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchange-templates?name={name}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetBySourceTokenType(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var sourceTokenType = fixture.Faker.Lorem.Word();

            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeTemplateGetRequest
            {
                SourceTokenType = sourceTokenType
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchange-templates?source_token_type={sourceTokenType}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPagination(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var size = fixture.Faker.Random.Int(1, 20);
            var page = fixture.Faker.Random.Int(1, 20);

            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeTemplateGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchange-templates?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithAllParameters(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var name = fixture.Faker.Lorem.Word();
            var sourceTokenType = fixture.Faker.Lorem.Word();
            var size = fixture.Faker.Random.Int(1, 20);
            var page = fixture.Faker.Random.Int(1, 20);

            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, new ExchangeTemplateGetRequest
            {
                Name = name,
                SourceTokenType = sourceTokenType,
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/exchange-templates?page={page}&size={size}&name={name}&source_token_type={sourceTokenType}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/exchange-templates", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ExchangeTemplateFactory.PaginatedExchangeTemplates();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/exchange-templates", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IExchangeTemplateClient, ExchangeTemplateGetRequest, RequestOptions, Task<PaginatedList<ExchangeTemplate>>> mut)
        {
            var error = Guid.NewGuid().ToString();

            fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

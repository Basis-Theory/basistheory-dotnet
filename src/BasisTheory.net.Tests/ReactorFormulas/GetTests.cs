using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.ReactorFormulas;
using BasisTheory.net.ReactorFormulas.Entities;
using BasisTheory.net.ReactorFormulas.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.ReactorFormulas.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ReactorFormulas
{
    public class GetTests : IClassFixture<ReactorFormulaFixture>
    {
        private readonly ReactorFormulaFixture _fixture;

        public GetTests(ReactorFormulaFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>>)(
                        async (client, request, options) => await client.GetAsync(request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>>)(
                        (client, request, options) =>  Task.FromResult(client.Get(request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetAll(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/reactor-formulas", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByName(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var name = _fixture.Faker.Lorem.Word();

            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorFormulaGetRequest
            {
                Name = name
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas?name={name}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetBySourceTokenType(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var sourceTokenType = _fixture.Faker.Lorem.Word();

            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorFormulaGetRequest
            {
                SourceTokenType = sourceTokenType
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas?source_token_type={sourceTokenType}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPagination(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var size = _fixture.Faker.Random.Int(1, 20);
            var page = _fixture.Faker.Random.Int(1, 20);

            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorFormulaGetRequest
            {
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas?page={page}&size={size}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithAllParameters(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var name = _fixture.Faker.Lorem.Word();
            var sourceTokenType = _fixture.Faker.Lorem.Word();
            var size = _fixture.Faker.Random.Int(1, 20);
            var page = _fixture.Faker.Random.Int(1, 20);

            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, new ReactorFormulaGetRequest
            {
                Name = name,
                SourceTokenType = sourceTokenType,
                PageSize = size,
                Page = page
            }, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas?page={page}&size={size}&name={name}&source_token_type={sourceTokenType}",
                requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithPerRequestApiKey(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/reactor-formulas", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetWithCorrelationId(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ReactorFormulaFactory.PaginatedReactorFormulas();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal("/reactor-formulas", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(
            Func<IReactorFormulaClient, ReactorFormulaGetRequest, RequestOptions, Task<PaginatedList<ReactorFormula>>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, null, null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

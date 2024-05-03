using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.ReactorFormulas;
using BasisTheory.net.ReactorFormulas.Entities;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.ReactorFormulas.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ReactorFormulas
{
    public class CreateTests : IClassFixture<ReactorFormulaFixture>
    {
        private readonly ReactorFormulaFixture _fixture;

        public CreateTests(ReactorFormulaFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object[]
                {
                    (Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>>)(
                        async (client, reactorFormula, options) => await client.CreateAsync(reactorFormula, options)
                    )
                };
                yield return new object[]
                {
                    (Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>>)(
                        (client, reactorFormula, options) => Task.FromResult(client.Create(reactorFormula, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreate(Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>> mut)
        {
            var content = ReactorFormulaFactory.ReactorFormula();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/reactor-formulas", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithPerRequestApiKey(Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ReactorFormulaFactory.ReactorFormula();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/reactor-formulas", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldCreateWithCustomHeaders(Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();
            var expectedIdempotencyKey = Guid.NewGuid().ToString();

            var content = ReactorFormulaFactory.ReactorFormula();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.Created, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(_fixture.Client, content, new RequestOptions
            {
                CorrelationId = expectedCorrelationId,
                IdempotencyKey = expectedIdempotencyKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Post, requestMessage.Method);
            Assert.Equal("/reactor-formulas", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("BT-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("BT-TRACE-ID").First());
            Assert.Equal(expectedIdempotencyKey, requestMessage.Headers.GetValues("BT-IDEMPOTENCY-KEY").First());
            _fixture.AssertUserAgent(requestMessage);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new ReactorFormula(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new ReactorFormula(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IReactorFormulaClient, ReactorFormula, RequestOptions, Task<ReactorFormula>> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, new ReactorFormula(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

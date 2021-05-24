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
using BasisTheory.net.ReactorFormulas.Requests;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.ReactorFormulas.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ReactorFormulas
{
    public class GetByIdTests : IClassFixture<ReactorFormulaFixture>
    {
        readonly ReactorFormulaFixture fixture;

        public GetByIdTests(ReactorFormulaFixture fixture)
        {
            this.fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>>)(
                        async (client, reactorFormulaId, request, options) =>
                            await client.GetByIdAsync(reactorFormulaId, request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>>)(
                        async (client, reactorFormulaId, request, options) =>
                            await client.GetByIdAsync(reactorFormulaId.ToString(), request, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>>)(
                        (client, reactorFormulaId, request, options) =>
                            Task.FromResult(client.GetById(reactorFormulaId, request, options))
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>>)(
                        (client, reactorFormulaId, request, options) =>
                            Task.FromResult(client.GetById(reactorFormulaId.ToString(), request, options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetById(Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>> mut)
        {
            var content = ReactorFormulaFactory.ReactorFormula();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content.Id, null, null);

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithPerRequestApiKey(Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var content = ReactorFormulaFactory.ReactorFormula();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content.Id, null, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldGetByIdWithCorrelationId(Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var content = ReactorFormulaFactory.ReactorFormula();
            var expectedSerialized = JsonConvert.SerializeObject(content);

            HttpRequestMessage requestMessage = null;
            fixture.SetupHandler(HttpStatusCode.OK, expectedSerialized, (message, _) => requestMessage = message);

            var response = await mut(fixture.Client, content.Id, null, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(expectedSerialized, JsonConvert.SerializeObject(response));
            Assert.Equal(HttpMethod.Get, requestMessage.Method);
            Assert.Equal($"/reactor-formulas/{content.Id}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>> mut)
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
        public async Task ShouldHandleEmptyErrorResponse(Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>> mut)
        {
            fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(fixture.Client, Guid.NewGuid(), null, null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IReactorFormulaClient, Guid, ReactorFormulaGetByIdRequest, RequestOptions, Task<ReactorFormula>> mut)
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

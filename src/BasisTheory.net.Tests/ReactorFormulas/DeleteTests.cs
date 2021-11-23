using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.ReactorFormulas;
using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tests.ReactorFormulas.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace BasisTheory.net.Tests.ReactorFormulas
{
    public class DeleteTests : IClassFixture<ReactorFormulaFixture>
    {
        private readonly ReactorFormulaFixture _fixture;

        public DeleteTests(ReactorFormulaFixture fixture)
        {
            _fixture = fixture;
        }

        public static IEnumerable<object[]> Methods
        {
            get
            {
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, RequestOptions, Task>)(
                        async (client, reactorFormulaId, options) => await client.DeleteAsync(reactorFormulaId, options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, RequestOptions, Task>)(
                        async (client, reactorFormulaId, options) => await client.DeleteAsync(reactorFormulaId.ToString(), options)
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, RequestOptions, Task>)(
                        (client, reactorFormulaId, options) => Task.Run(() => client.Delete(reactorFormulaId, options))
                    )
                };
                yield return new object []
                {
                    (Func<IReactorFormulaClient, Guid, RequestOptions, Task>)(
                        (client, reactorFormulaId, options) => Task.Run(() => client.Delete(reactorFormulaId.ToString(), options))
                    )
                };
            }
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDelete(Func<IReactorFormulaClient, Guid, RequestOptions, Task> mut)
        {
            var reactorFormulaId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, reactorFormulaId, null);

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/reactor-formulas/{reactorFormulaId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithPerRequestApiKey(Func<IReactorFormulaClient, Guid, RequestOptions, Task> mut)
        {
            var expectedApiKey = Guid.NewGuid().ToString();

            var reactorFormulaId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, reactorFormulaId, new RequestOptions
            {
                ApiKey = expectedApiKey
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/reactor-formulas/{reactorFormulaId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(expectedApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldDeleteWithCorrelationId(Func<IReactorFormulaClient, Guid, RequestOptions, Task> mut)
        {
            var expectedCorrelationId = Guid.NewGuid().ToString();

            var reactorFormulaId = Guid.NewGuid();

            HttpRequestMessage requestMessage = null;
            _fixture.SetupHandler(HttpStatusCode.NoContent, null, (message, _) => requestMessage = message);

            await mut(_fixture.Client, reactorFormulaId, new RequestOptions
            {
                CorrelationId = expectedCorrelationId
            });

            Assert.Equal(HttpMethod.Delete, requestMessage.Method);
            Assert.Equal($"/reactor-formulas/{reactorFormulaId}", requestMessage.RequestUri?.PathAndQuery);
            Assert.Equal(_fixture.ApiKey, requestMessage.Headers.GetValues("X-API-KEY").First());
            Assert.Equal(expectedCorrelationId, requestMessage.Headers.GetValues("bt-trace-id").First());
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldBubbleUpBasisTheoryErrors(Func<IReactorFormulaClient, Guid, RequestOptions, Task> mut)
        {
            var error = BasisTheoryErrorFactory.BasisTheoryError();
            var expectedSerializedError = JsonConvert.SerializeObject(error);

            _fixture.SetupHandler(HttpStatusCode.BadRequest, expectedSerializedError);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));
            var actualSerializedError = JsonConvert.SerializeObject(exception.Error);

            Assert.Equal(expectedSerializedError, actualSerializedError);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleEmptyErrorResponse(Func<IReactorFormulaClient, Guid, RequestOptions, Task> mut)
        {
            _fixture.SetupHandler(HttpStatusCode.Forbidden);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(403, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }

        [Theory]
        [MemberData(nameof(Methods))]
        public async Task ShouldHandleNonBasisTheoryErrorResponse(Func<IReactorFormulaClient, Guid, RequestOptions, Task> mut)
        {
            var error = Guid.NewGuid().ToString();

            _fixture.SetupHandler(HttpStatusCode.InternalServerError, error);

            var exception = await Assert.ThrowsAsync<BasisTheoryException>(() => mut(_fixture.Client, Guid.NewGuid(), null));

            Assert.Equal(500, exception.Error.Status);
            Assert.Null(exception.Error.Title);
            Assert.Null(exception.Error.Detail);
        }
    }
}

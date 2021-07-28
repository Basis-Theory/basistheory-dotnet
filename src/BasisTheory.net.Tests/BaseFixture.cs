using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Moq;
using Moq.Protected;

namespace BasisTheory.net.Tests
{
    public abstract class BaseFixture : IDisposable
    {
        public readonly Faker Faker;
        public readonly string ApiKey;
        public readonly Mock<HttpMessageHandler> MessageHandler;
        public readonly HttpClient HttpClient;

        public BaseFixture()
        {
            Faker = new Faker();
            ApiKey = Guid.NewGuid().ToString();
            MessageHandler = new Mock<HttpMessageHandler>();
            HttpClient = new HttpClient(MessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }

        public void SetupHandler(HttpStatusCode statusCode, string content = null,
            Action<HttpRequestMessage, CancellationToken> messageHandler = null)
        {
            var httpResponseMessage = string.IsNullOrEmpty(content) ?
                new HttpResponseMessage { StatusCode = statusCode } :
                new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                };

            var returnResult = MessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            if (messageHandler != null)
                returnResult.Callback(messageHandler);
        }
    }
}

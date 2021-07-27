using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Tokens;
using Moq;
using Moq.Protected;

namespace BasisTheory.net.Tests.Tokens.Helpers
{
    public class TokenFixture : IDisposable
    {
        public readonly string ApiKey;
        public readonly Mock<HttpMessageHandler> MessageHandler;
        public readonly HttpClient HttpClient;
        public readonly ITokenClient Client;

        public TokenFixture()
        {
            ApiKey = Guid.NewGuid().ToString();
            MessageHandler = new Mock<HttpMessageHandler>();
            HttpClient = new HttpClient(MessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
            Client = new TokenClient(apiKey: ApiKey, httpClient: HttpClient);
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

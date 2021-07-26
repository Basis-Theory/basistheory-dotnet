using System;
using System.Net.Http;
using BasisTheory.net.Tokens;
using Moq;

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
            HttpClient.Dispose();
        }
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Utilities;
using Bogus;
using Moq;
using Moq.Protected;
using Xunit;

namespace BasisTheory.net.Tests.Helpers
{
    public abstract class BaseFixture : IDisposable
    {
        public readonly Faker Faker;
        public readonly string ApiKey;
        private readonly Mock<HttpMessageHandler> _messageHandler;
        protected readonly HttpClient HttpClient;
        protected readonly ApplicationInfo AppInfo;

        protected BaseFixture()
        {
            Faker = new Faker();
            ApiKey = Guid.NewGuid().ToString();
            _messageHandler = new Mock<HttpMessageHandler>();
            HttpClient = new HttpClient(_messageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost/")
            };
            AppInfo = new ApplicationInfo()
            {
                Name = "Test",
                Version = "1.0",
                Url = "http://test/"
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

            var returnResult = _messageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            if (messageHandler != null)
                returnResult.Callback(messageHandler);
        }

        public void AssertUserAgent(HttpRequestMessage requestMessage)
        {
            Assert.Equal(UserAgentUtility.BuildUserAgentString(AppInfo), string.Join(" ", requestMessage.Headers.GetValues("User-Agent")));
            Assert.Equal(UserAgentUtility.BuildBtClientUserAgentString(AppInfo), requestMessage.Headers.GetValues("BT-CLIENT-USER-AGENT").First());
        }
    }
}

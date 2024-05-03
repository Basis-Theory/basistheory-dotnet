using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Utilities;
using Bogus;
using NSubstitute;
using Xunit;

namespace BasisTheory.net.Tests.Helpers
{
    public abstract class BaseFixture : IDisposable
    {
        public readonly Faker Faker;
        public readonly string ApiKey;
        private readonly HttpMessageHandler _messageHandler;
        protected readonly HttpClient HttpClient;
        protected readonly ApplicationInfo AppInfo;

        protected BaseFixture()
        {
            Faker = new Faker();
            ApiKey = Guid.NewGuid().ToString();
            _messageHandler = Substitute.For<HttpMessageHandler>();
            HttpClient = new HttpClient(_messageHandler)
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
            var httpResponseMessage = string.IsNullOrEmpty(content)
                ? new HttpResponseMessage { StatusCode = statusCode }
                : new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                };

            var returnResult = _messageHandler
                .Protected("SendAsync", Arg.Any<HttpRequestMessage>(),
                    Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(httpResponseMessage));

            if (messageHandler != null)
                returnResult.AndDoes(info => messageHandler.Invoke(
                    info.Arg<HttpRequestMessage>(),
                    info.Arg<CancellationToken>()
                ));
        }

        public void AssertUserAgent(HttpRequestMessage requestMessage)
        {
            Assert.Equal(UserAgentUtility.BuildUserAgentString(AppInfo),
                string.Join(" ", requestMessage.Headers.GetValues("User-Agent")));
            Assert.Equal(UserAgentUtility.BuildBtClientUserAgentString(AppInfo),
                requestMessage.Headers.GetValues("BT-CLIENT-USER-AGENT").First());
        }
    }

    public static class Reflect
    {
        public static object Protected(this object target, string name, params object[] args)
        {
            var type = target.GetType();
            var method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(x => x.Name == name);

            return method.Invoke(target, args);
        }
    }
}
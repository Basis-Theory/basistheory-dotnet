using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Utilities;
using Bogus;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BasisTheory.net.Tests.Common;

public abstract class BaseClientTests
{
    protected class BaseClientImpl : BaseClient
    {
        protected override string BasePath { get; }

        public BaseClientImpl(string apiKey = null,
            HttpClient httpClient = null,
            string apiBaseUrl = DefaultBaseUrl,
            ApplicationInfo appInfo = null) : base(apiKey, httpClient, apiBaseUrl, appInfo)
        {
        }

        public HttpClient GetHttpClient() => HttpClient;
    }

    protected ApplicationInfo ExpectedAppInfo;
    protected BaseClientImpl Client;


    [Fact]
    public void ShouldSetUserAgentDefaultRequestHeader()
    {
        var expectedSdkVersion = Assembly.GetAssembly(typeof(BaseClient))?.GetName().Version?.ToString(3);
        var expectedAppInfoUserAgent = $"({ExpectedAppInfo.Name}; {ExpectedAppInfo.Version}; {ExpectedAppInfo.Url})";
        var expectedUserAgent = $"BasisTheory.net/{expectedSdkVersion} {expectedAppInfoUserAgent}";

        var actualUserAgentHeader = Client.GetHttpClient().DefaultRequestHeaders.UserAgent;

        Assert.NotNull(actualUserAgentHeader);
        Assert.Equal(expectedUserAgent, actualUserAgentHeader.ToString());
    }

    [Fact]
    public void ShouldSetBtClientUserAgentDefaultRequestHeader()
    {
        var expectedSdkVersion = Assembly.GetAssembly(typeof(BaseClient))?.GetName().Version?.ToString(3);

        var btClientUserAgentHeaderCollection = Client.GetHttpClient().DefaultRequestHeaders.GetValues("BT-CLIENT-USER-AGENT").ToList();
        Assert.Single(btClientUserAgentHeaderCollection);

        var actualUserAgentHeader = btClientUserAgentHeaderCollection.First();
        Assert.NotNull(actualUserAgentHeader);

        var parsedHeader = JsonUtility.DeserializeObject<dynamic>(actualUserAgentHeader);

        var actualClient = (string)parsedHeader.client;
        Assert.Equal("BasisTheory.net", actualClient);

        var actualClientVersion = (string)parsedHeader.client_version;
        Assert.Equal(expectedSdkVersion, actualClientVersion);

        var actualOsVersion = (string)parsedHeader.os_version;
        Assert.Equal(RuntimeInformation.OSDescription, actualOsVersion);

        var actualRuntimeVersion = (string)parsedHeader.runtime_version;
        Assert.NotNull(actualRuntimeVersion);

        var actualApplication = (JObject)parsedHeader.application;
        Assert.Equal(ExpectedAppInfo.Name, actualApplication["name"]?.Value<string>());
        Assert.Equal(ExpectedAppInfo.Version, actualApplication["version"]?.Value<string>());
        Assert.Equal(ExpectedAppInfo.Url, actualApplication["url"]?.Value<string>());
        Assert.NotNull(actualApplication);
    }

    public class GivenABaseClientWithoutHttpClientConfigured : BaseClientTests
    {
        public GivenABaseClientWithoutHttpClientConfigured()
        {
            var faker = new Faker();
            ExpectedAppInfo = new ApplicationInfo
            {
                Name = faker.Random.Words(),
                Url = faker.Internet.Url(),
                Version = faker.System.Semver()
            };

            Client = new BaseClientImpl(appInfo: ExpectedAppInfo);
        }
    }

    public class GivenABaseClientWithHttpClientPreConfigured : BaseClientTests
    {
        public GivenABaseClientWithHttpClientPreConfigured()
        {
            var faker = new Faker();
            ExpectedAppInfo = new ApplicationInfo
            {
                Name = faker.Random.Words(),
                Url = faker.Internet.Url(),
                Version = faker.System.Semver()
            };

            Client = new BaseClientImpl(httpClient: new HttpClient(), appInfo: ExpectedAppInfo);
        }
    }
}

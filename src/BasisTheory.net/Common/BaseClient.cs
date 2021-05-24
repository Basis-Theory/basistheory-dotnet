using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using Polly;
using Polly.Extensions.Http;

namespace BasisTheory.net.Common
{
    public abstract class BaseClient
    {
        protected const string DefaultBaseUrl = "https://api.basistheory.com";

        private string ApiKey { get; }
        private HttpClient HttpClient { get; }

        private Uri BaseApiUrl { get; set; }

        protected abstract string BasePath { get; }

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        internal BaseClient(string apiKey = null,
            HttpClient httpClient = null,
            string apiBaseUrl = DefaultBaseUrl)
        {
            ApiKey = apiKey;

            if (Uri.TryCreate(apiBaseUrl, UriKind.Absolute, out var baseUri))
                BaseApiUrl = baseUri;
            else
                throw new ArgumentException("Invalid URI format", nameof(apiBaseUrl));

            HttpClient = httpClient ?? BuildDefaultHttpClient();

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        protected T Get<T>(string path, GetRequest request = null, RequestOptions requestOptions = null)
        {
            return this.GetAsync<T>(path, request, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> GetAsync<T>(string path, GetRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            var requestPath = path;
            var queryString = request?.BuildQuery();

            if (!string.IsNullOrWhiteSpace(queryString))
                requestPath = $"{requestPath}?{queryString}";

            var content = await RequestAsync(HttpMethod.Get, requestPath, null, requestOptions, cancellationToken);
            return JsonConvert.DeserializeObject<T>(content);
        }

        protected T Post<T>(string path, object body, RequestOptions requestOptions)
        {
            return this.PostAsync<T>(path, body, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> PostAsync<T>(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var content = await RequestAsync(HttpMethod.Post, path, body, requestOptions, cancellationToken);
            return JsonConvert.DeserializeObject<T>(content);
        }

        protected void Post(string path, object body, RequestOptions requestOptions)
        {
            this.PostAsync(path, body, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task PostAsync(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            await RequestAsync(HttpMethod.Post, path, body, requestOptions, cancellationToken);
        }

        protected T Put<T>(string path, object body, RequestOptions requestOptions)
        {
            return this.PutAsync<T>(path, body, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> PutAsync<T>(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var content = await RequestAsync(HttpMethod.Put, path, body, requestOptions, cancellationToken);
            return JsonConvert.DeserializeObject<T>(content);
        }

        protected void Delete(string path, RequestOptions requestOptions)
        {
            this.DeleteAsync(path, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task DeleteAsync(string path, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            await RequestAsync(HttpMethod.Delete, path, null, requestOptions, cancellationToken);
        }

        private async Task<string> RequestAsync(HttpMethod method, string path, object body,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var message = new HttpRequestMessage(method, path);
            SetRequestHeaders(message, requestOptions);

            if (body != null)
                message.Content = new StringContent(JsonConvert.SerializeObject(body, _jsonSerializerSettings));

            var response = await HttpClient.SendAsync(message, cancellationToken)
                .ConfigureAwait(false);

            var responseStream = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            var content = await responseStream.ReadToEndAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw ProcessErrorResponse(response, content);
            }

            return content;
        }

        private static BasisTheoryException ProcessErrorResponse(HttpResponseMessage response, string content)
        {
            var error = JsonConvert.DeserializeObject<BasisTheoryError>(content);
            var errorMessage = error?.Title ?? error?.Detail ?? content;

            return new BasisTheoryException(response.StatusCode, error, errorMessage);
        }

        private void SetRequestHeaders(HttpRequestMessage message, RequestOptions requestOptions)
        {
            var apiKey = requestOptions.ApiKey ?? ApiKey;
            if (!string.IsNullOrEmpty(apiKey))
                message.Headers.Add("X-API-KEY", apiKey);

            if (!string.IsNullOrEmpty(requestOptions.CorrelationId))
                message.Headers.Add("bt-trace-id", requestOptions.CorrelationId);
        }

        private HttpClient BuildDefaultHttpClient()
        {
            return new HttpClient(new PolicyHttpMessageHandler(GetRetryPolicy()))
            {
                Timeout = TimeSpan.FromSeconds(90),
                BaseAddress = BaseApiUrl
            };
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}

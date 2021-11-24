using System;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common.Errors;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Utilities;
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
        }

        protected T Get<T>(string path, GetRequest request = null, RequestOptions requestOptions = null)
        {
            return GetAsync<T>(path, request, requestOptions).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> GetAsync<T>(string path, GetRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            var requestPath = path;
            var queryString = request?.BuildQuery();

            if (!string.IsNullOrWhiteSpace(queryString))
                requestPath = $"{requestPath}?{queryString}";

            var content = await RequestAsync(HttpMethod.Get, requestPath, null, requestOptions, cancellationToken);
            return JsonUtility.DeserializeObject<T>(content);
        }

        protected T Post<T>(string path, object body, RequestOptions requestOptions)
        {
            return PostAsync<T>(path, body, requestOptions).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> PostAsync<T>(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var content = await RequestAsync(HttpMethod.Post, path, body, requestOptions, cancellationToken);
            return JsonUtility.DeserializeObject<T>(content);
        }

        protected void Post(string path, object body, RequestOptions requestOptions)
        {
            PostAsync(path, body, requestOptions).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task PostAsync(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            await RequestAsync(HttpMethod.Post, path, body, requestOptions, cancellationToken);
        }

        protected T Put<T>(string path, object body, RequestOptions requestOptions)
        {
            return PutAsync<T>(path, body, requestOptions).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> PutAsync<T>(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var content = await RequestAsync(HttpMethod.Put, path, body, requestOptions, cancellationToken);
            return JsonUtility.DeserializeObject<T>(content);
        }

        protected T Patch<T>(string path, object body, RequestOptions requestOptions)
        {
            return PatchAsync<T>(path, body, requestOptions).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> PatchAsync<T>(string path, object body, RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var content = await RequestAsync(HttpMethod.Patch, path, body, requestOptions, cancellationToken);
            return JsonUtility.DeserializeObject<T>(content);
        }

        protected void Delete(string path, RequestOptions requestOptions)
        {
            DeleteAsync(path, requestOptions)
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
                message.Content = new StringContent(JsonUtility.SerializeObject(body), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await HttpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);

            var responseStream = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            var content = await responseStream.ReadToEndAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw ProcessErrorResponse(response, content);

            return content;
        }

        private static BasisTheoryException ProcessErrorResponse(HttpResponseMessage response, string content)
        {
            var error = new BasisTheoryError
            {
                Status = (int) response.StatusCode
            };
            var errorMessage = content;

            if (string.IsNullOrEmpty(content))
                return new BasisTheoryException(response.StatusCode, error, errorMessage);

            try
            {
                error = JsonUtility.DeserializeObject<BasisTheoryError>(content);
                errorMessage = error?.Title ?? error?.Detail ?? content;
            }
            catch (JsonReaderException)
            {
                errorMessage = string.Empty;
            }

            return new BasisTheoryException(response.StatusCode, error, errorMessage);
        }

        private void SetRequestHeaders(HttpRequestMessage message, RequestOptions requestOptions)
        {
            var apiKey = requestOptions?.ApiKey ?? ApiKey;
            if (!string.IsNullOrEmpty(apiKey))
                message.Headers.Add("X-API-KEY", apiKey);

            if (!string.IsNullOrEmpty(requestOptions?.CorrelationId))
                message.Headers.Add("bt-trace-id", requestOptions.CorrelationId);
        }

        private HttpClient BuildDefaultHttpClient()
        {
            var handler = new PolicyHttpMessageHandler(GetRetryPolicy())
            {
                InnerHandler = new HttpClientHandler()
            };

            return new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(90),
                BaseAddress = BaseApiUrl
            };
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}

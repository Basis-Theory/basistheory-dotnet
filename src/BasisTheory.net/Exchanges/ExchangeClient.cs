using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Exchanges.Entities;
using BasisTheory.net.Exchanges.Requests;

namespace BasisTheory.net.Exchanges
{
    public interface IExchangeClient
    {
        Exchange GetById(Guid exchangeId, ExchangeGetByIdRequest request = null,
            RequestOptions requestOptions = null);

        Task<Exchange> GetByIdAsync(Guid exchangeId, ExchangeGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        PaginatedList<Exchange> Get(ExchangeGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Exchange>> GetAsync(ExchangeGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Exchange Create(Exchange exchange, RequestOptions requestOptions = null);

        Task<Exchange> CreateAsync(Exchange exchange, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Exchange Update(Guid exchangeId, Exchange exchange, RequestOptions requestOptions = null);

        Task<Exchange> UpdateAsync(Guid exchangeId, Exchange exchange, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid exchangeId, RequestOptions requestOptions = null);

        Task DeleteAsync(Guid exchangeId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class ExchangeClient : BaseClient, IExchangeClient
    {
        protected override string BasePath => "exchanges";

        public ExchangeClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public Exchange GetById(Guid exchangeId, ExchangeGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<Exchange>($"{BasePath}/{exchangeId}", request, requestOptions);
        }

        public async Task<Exchange> GetByIdAsync(Guid exchangeId, ExchangeGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Exchange>($"{BasePath}/{exchangeId}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<Exchange> Get(ExchangeGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Exchange>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Exchange>> GetAsync(ExchangeGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Exchange>>(BasePath, request, requestOptions, cancellationToken);
        }

        public Exchange Create(Exchange exchange, RequestOptions requestOptions = null)
        {
            return Post<Exchange>(BasePath, exchange, requestOptions);
        }

        public async Task<Exchange> CreateAsync(Exchange exchange, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Exchange>(BasePath, exchange, requestOptions, cancellationToken);
        }

        public Exchange Update(Guid exchangeId, Exchange exchange, RequestOptions requestOptions = null)
        {
            return Put<Exchange>($"{BasePath}/{exchangeId}", exchange, requestOptions);
        }

        public async Task<Exchange> UpdateAsync(Guid exchangeId, Exchange exchange,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<Exchange>($"{BasePath}/{exchangeId}", exchange, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid exchangeId, RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/{exchangeId}", requestOptions);
        }

        public async Task DeleteAsync(Guid exchangeId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{exchangeId}", requestOptions, cancellationToken);
        }
    }
}

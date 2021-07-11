using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.ExchangeTemplates.Entities;
using BasisTheory.net.ExchangeTemplates.Requests;

namespace BasisTheory.net.ExchangeTemplates
{
    public interface IExchangeTemplateClient
    {
        ExchangeTemplate GetById(Guid exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null);
        ExchangeTemplate GetById(string exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null);
        Task<ExchangeTemplate> GetByIdAsync(Guid exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        Task<ExchangeTemplate> GetByIdAsync(string exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        PaginatedList<ExchangeTemplate> Get(ExchangeTemplateGetRequest request = null,
            RequestOptions requestOptions = null);
        Task<PaginatedList<ExchangeTemplate>> GetAsync(ExchangeTemplateGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ExchangeTemplate Create(ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null);
        Task<ExchangeTemplate> CreateAsync(ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ExchangeTemplate Update(Guid exchangeTemplateId, ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null);
        ExchangeTemplate Update(string exchangeTemplateId, ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null);
        Task<ExchangeTemplate> UpdateAsync(Guid exchangeTemplateId, ExchangeTemplate exchangeTemplate,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<ExchangeTemplate> UpdateAsync(string exchangeTemplateId, ExchangeTemplate exchangeTemplate,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid exchangeTemplateId, RequestOptions requestOptions = null);
        void Delete(string exchangeTemplateId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid exchangeTemplateId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string exchangeTemplateId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class ExchangeTemplateClient : BaseClient, IExchangeTemplateClient
    {
        protected override string BasePath => "exchange-templates";

        public ExchangeTemplateClient(string apiKey = null, HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public ExchangeTemplate GetById(Guid exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return GetById(exchangeTemplateId.ToString(), request, requestOptions);
        }

        public ExchangeTemplate GetById(string exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<ExchangeTemplate>($"{BasePath}/{exchangeTemplateId}", request, requestOptions);
        }

        public async Task<ExchangeTemplate> GetByIdAsync(Guid exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(exchangeTemplateId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<ExchangeTemplate> GetByIdAsync(string exchangeTemplateId, ExchangeTemplateGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<ExchangeTemplate>($"{BasePath}/{exchangeTemplateId}", request, requestOptions,
                cancellationToken);
        }

        public PaginatedList<ExchangeTemplate> Get(ExchangeTemplateGetRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<ExchangeTemplate>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<ExchangeTemplate>> GetAsync(ExchangeTemplateGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<ExchangeTemplate>>(BasePath, request, requestOptions,
                cancellationToken);
        }

        public ExchangeTemplate Create(ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null)
        {
            return Post<ExchangeTemplate>(BasePath, exchangeTemplate, requestOptions);
        }

        public async Task<ExchangeTemplate> CreateAsync(ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<ExchangeTemplate>(BasePath, exchangeTemplate, requestOptions, cancellationToken);
        }

        public ExchangeTemplate Update(Guid exchangeTemplateId, ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null)
        {
            return Update(exchangeTemplateId.ToString(), exchangeTemplate, requestOptions);
        }

        public ExchangeTemplate Update(string exchangeTemplateId, ExchangeTemplate exchangeTemplate, RequestOptions requestOptions = null)
        {
            return Put<ExchangeTemplate>($"{BasePath}/{exchangeTemplateId}", exchangeTemplate, requestOptions);
        }

        public async Task<ExchangeTemplate> UpdateAsync(Guid exchangeTemplateId, ExchangeTemplate exchangeTemplate,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(exchangeTemplateId.ToString(), exchangeTemplate, requestOptions,
                cancellationToken);
        }

        public async Task<ExchangeTemplate> UpdateAsync(string exchangeTemplateId, ExchangeTemplate exchangeTemplate,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<ExchangeTemplate>($"{BasePath}/{exchangeTemplateId}", exchangeTemplate, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid exchangeTemplateId, RequestOptions requestOptions = null)
        {
            Delete(exchangeTemplateId.ToString(), requestOptions);
        }

        public new void Delete(string exchangeTemplateId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{exchangeTemplateId}", requestOptions);
        }

        public async Task DeleteAsync(Guid exchangeTemplateId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync(exchangeTemplateId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(string exchangeTemplateId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{exchangeTemplateId}", requestOptions, cancellationToken);
        }
    }
}

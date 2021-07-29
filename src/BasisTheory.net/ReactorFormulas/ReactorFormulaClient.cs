using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.ReactorFormulas.Entities;
using BasisTheory.net.ReactorFormulas.Requests;

namespace BasisTheory.net.ReactorFormulas
{
    public interface IReactorFormulaClient
    {
        ReactorFormula GetById(Guid reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null);
        ReactorFormula GetById(string reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null);
        Task<ReactorFormula> GetByIdAsync(Guid reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        Task<ReactorFormula> GetByIdAsync(string reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        PaginatedList<ReactorFormula> Get(ReactorFormulaGetRequest request = null,
            RequestOptions requestOptions = null);
        Task<PaginatedList<ReactorFormula>> GetAsync(ReactorFormulaGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ReactorFormula Create(ReactorFormula reactorFormula, RequestOptions requestOptions = null);
        Task<ReactorFormula> CreateAsync(ReactorFormula reactorFormula, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ReactorFormula Update(Guid reactorFormulaId, ReactorFormula reactorFormula, RequestOptions requestOptions = null);
        ReactorFormula Update(string reactorFormulaId, ReactorFormula reactorFormula, RequestOptions requestOptions = null);
        Task<ReactorFormula> UpdateAsync(Guid reactorFormulaId, ReactorFormula reactorFormula, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<ReactorFormula> UpdateAsync(string reactorFormulaId, ReactorFormula reactorFormula, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid reactorFormulaId, RequestOptions requestOptions = null);
        void Delete(string reactorFormulaId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid reactorFormulaId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string reactorFormulaId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class ReactorFormulaClient : BaseClient, IReactorFormulaClient
    {
        protected override string BasePath => "reactor-formulas";

        public ReactorFormulaClient(string apiKey = null, HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public ReactorFormula GetById(Guid reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return GetById(reactorFormulaId.ToString(), request, requestOptions);
        }

        public ReactorFormula GetById(string reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<ReactorFormula>($"{BasePath}/{reactorFormulaId}", request, requestOptions);
        }

        public async Task<ReactorFormula> GetByIdAsync(Guid reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(reactorFormulaId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<ReactorFormula> GetByIdAsync(string reactorFormulaId, ReactorFormulaGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<ReactorFormula>($"{BasePath}/{reactorFormulaId}", request, requestOptions,
                cancellationToken);
        }

        public PaginatedList<ReactorFormula> Get(ReactorFormulaGetRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<ReactorFormula>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<ReactorFormula>> GetAsync(ReactorFormulaGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<ReactorFormula>>(BasePath, request, requestOptions,
                cancellationToken);
        }

        public ReactorFormula Create(ReactorFormula reactorFormula, RequestOptions requestOptions = null)
        {
            return Post<ReactorFormula>(BasePath, reactorFormula, requestOptions);
        }

        public async Task<ReactorFormula> CreateAsync(ReactorFormula reactorFormula, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<ReactorFormula>(BasePath, reactorFormula, requestOptions, cancellationToken);
        }

        public ReactorFormula Update(Guid reactorFormulaId, ReactorFormula reactorFormula, RequestOptions requestOptions = null)
        {
            return Update(reactorFormulaId.ToString(), reactorFormula, requestOptions);
        }

        public ReactorFormula Update(string reactorFormulaId, ReactorFormula reactorFormula, RequestOptions requestOptions = null)
        {
            return Put<ReactorFormula>($"{BasePath}/{reactorFormulaId}", reactorFormula, requestOptions);
        }

        public async Task<ReactorFormula> UpdateAsync(Guid reactorFormulaId, ReactorFormula reactorFormula,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(reactorFormulaId.ToString(), reactorFormula, requestOptions,
                cancellationToken);
        }

        public async Task<ReactorFormula> UpdateAsync(string reactorFormulaId, ReactorFormula reactorFormula,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<ReactorFormula>($"{BasePath}/{reactorFormulaId}", reactorFormula, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid reactorFormulaId, RequestOptions requestOptions = null)
        {
            Delete(reactorFormulaId.ToString(), requestOptions);
        }

        public new void Delete(string reactorFormulaId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{reactorFormulaId}", requestOptions);
        }

        public async Task DeleteAsync(Guid reactorFormulaId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync(reactorFormulaId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(string reactorFormulaId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{reactorFormulaId}", requestOptions, cancellationToken);
        }
    }
}

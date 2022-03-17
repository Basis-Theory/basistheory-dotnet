using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks.Entities;
using BasisTheory.net.Atomic.Banks.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;

namespace BasisTheory.net.Atomic.Banks
{
    public interface IAtomicBankClient
    {
        AtomicBank GetById(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null);
        AtomicBank GetById(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null);
        Task<AtomicBank> GetByIdAsync(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<AtomicBank> GetByIdAsync(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<AtomicBank> Get(BankGetRequest request = null, RequestOptions requestOptions = null);
        Task<PaginatedList<AtomicBank>> GetAsync(BankGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicBank Create(AtomicBank atomicBank, RequestOptions requestOptions = null);
        Task<AtomicBank> CreateAsync(AtomicBank atomicBank, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicBank Update(Guid atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null);
        AtomicBank Update(string atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null);
        Task<AtomicBank> UpdateAsync(Guid atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<AtomicBank> UpdateAsync(string atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid atomicBankId, RequestOptions requestOptions = null);
        void Delete(string atomicBankId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid atomicBankId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string atomicBankId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ReactResponse React(Guid atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null);
        ReactResponse React(string atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null);
        Task<ReactResponse> ReactAsync(Guid atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<ReactResponse> ReactAsync(string atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class AtomicBankClient : BaseClient, IAtomicBankClient
    {
        protected override string BasePath => "atomic/banks";

        public AtomicBankClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl, ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public AtomicBank GetById(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return GetById(atomicBankId.ToString(), request, requestOptions);
        }

        public AtomicBank GetById(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<AtomicBank>($"{BasePath}/{atomicBankId}", request, requestOptions);
        }

        public async Task<AtomicBank> GetByIdAsync(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(atomicBankId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<AtomicBank> GetByIdAsync(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<AtomicBank>($"{BasePath}/{atomicBankId}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<AtomicBank> Get(BankGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<AtomicBank>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<AtomicBank>> GetAsync(BankGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<AtomicBank>>(BasePath, request, requestOptions, cancellationToken);
        }

        public AtomicBank Create(AtomicBank atomicBank, RequestOptions requestOptions = null)
        {
            return Post<AtomicBank>(BasePath, atomicBank, requestOptions);
        }

        public async Task<AtomicBank> CreateAsync(AtomicBank atomicBank, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PostAsync<AtomicBank>(BasePath, atomicBank, requestOptions, cancellationToken);
        }

        public AtomicBank Update(Guid atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null)
        {
            return Update(atomicBankId.ToString(), request, requestOptions);
        }

        public AtomicBank Update(string atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null)
        {
            return Patch<AtomicBank>($"{BasePath}/{atomicBankId}", request, requestOptions);
        }

        public async Task<AtomicBank> UpdateAsync(Guid atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(atomicBankId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<AtomicBank> UpdateAsync(string atomicBankId, UpdateAtomicBankRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PatchAsync<AtomicBank>($"{BasePath}/{atomicBankId}", request, requestOptions, cancellationToken);
        }

        public void Delete(Guid atomicBankId, RequestOptions requestOptions = null)
        {
            Delete(atomicBankId.ToString(), requestOptions);
        }

        public new void Delete(string atomicBankId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{atomicBankId}", requestOptions);
        }

        public async Task DeleteAsync(Guid atomicBankId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(atomicBankId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(string atomicBankId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{atomicBankId}", requestOptions, cancellationToken);
        }

        public ReactResponse React(Guid atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null)
        {
            return React(atomicBankId.ToString(), request, requestOptions);
        }

        public ReactResponse React(string atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null)
        {
            return Post<ReactResponse>($"{BasePath}/{atomicBankId}/react", request, requestOptions);
        }

        public async Task<ReactResponse> ReactAsync(Guid atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await ReactAsync(atomicBankId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<ReactResponse> ReactAsync(string atomicBankId, AtomicReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<ReactResponse>($"{BasePath}/{atomicBankId}/react", request, requestOptions, cancellationToken);
        }
    }
}

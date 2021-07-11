using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks.Entities;
using BasisTheory.net.Atomic.Banks.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;

namespace BasisTheory.net.Atomic.Banks
{
    public interface IAtomicBankClient
    {
        AtomicBank GetById(Guid tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null);
        AtomicBank GetById(string tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null);
        Task<AtomicBank> GetByIdAsync(Guid tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<AtomicBank> GetByIdAsync(string tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<AtomicBank> Get(BankGetRequest request = null, RequestOptions requestOptions = null);
        Task<PaginatedList<AtomicBank>> GetAsync(BankGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicBank Create(AtomicBank bank, RequestOptions requestOptions = null);
        Task<AtomicBank> CreateAsync(AtomicBank bank, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid tokenId, RequestOptions requestOptions = null);
        void Delete(string tokenId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string tokenId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class AtomicBankClient : BaseClient, IAtomicBankClient
    {
        protected override string BasePath => "atomic/banks";

        public AtomicBankClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public AtomicBank GetById(Guid tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return GetById(tokenId.ToString(), request, requestOptions);
        }

        public AtomicBank GetById(string tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            var decryptPath = request?.Decrypt ?? false ? "/decrypt" : string.Empty;

            return Get<AtomicBank>($"{BasePath}/{tokenId}{decryptPath}", request, requestOptions);
        }

        public async Task<AtomicBank> GetByIdAsync(Guid tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(tokenId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<AtomicBank> GetByIdAsync(string tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var decryptPath = request?.Decrypt ?? false ? "/decrypt" : string.Empty;

            return await GetAsync<AtomicBank>($"{BasePath}/{tokenId}{decryptPath}", request, requestOptions, cancellationToken);
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

        public AtomicBank Create(AtomicBank bank, RequestOptions requestOptions = null)
        {
            return Post<AtomicBank>(BasePath, bank, requestOptions);
        }

        public async Task<AtomicBank> CreateAsync(AtomicBank bank, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PostAsync<AtomicBank>(BasePath, bank, requestOptions, cancellationToken);
        }

        public void Delete(Guid tokenId, RequestOptions requestOptions = null)
        {
            Delete(tokenId.ToString(), requestOptions);
        }

        public new void Delete(string tokenId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{tokenId}", requestOptions);
        }

        public async Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(tokenId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(string tokenId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{tokenId}", requestOptions, cancellationToken);
        }
    }
}

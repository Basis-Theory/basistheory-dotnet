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

        Task<AtomicBank> GetByIdAsync(Guid tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<AtomicBank> Get(BankGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<AtomicBank>> GetAsync(BankGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicBank Create(AtomicBank bank, RequestOptions requestOptions = null);

        Task<AtomicBank> CreateAsync(AtomicBank bank, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid tokenId, RequestOptions requestOptions = null);

        Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null,
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
            var decryptPath = request?.DecryptBank ?? false ? "/decrypt" : string.Empty;

            return Get<AtomicBank>($"{BasePath}/{tokenId}{decryptPath}", request, requestOptions);
        }

        public async Task<AtomicBank> GetByIdAsync(Guid tokenId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var decryptPath = request?.DecryptBank ?? false ? "/decrypt" : string.Empty;

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
            Delete($"{BasePath}/{tokenId}", requestOptions);
        }

        public async Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{tokenId}", requestOptions, cancellationToken);
        }
    }
}

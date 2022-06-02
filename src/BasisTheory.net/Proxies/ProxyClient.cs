using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Proxies.Entities;
using BasisTheory.net.Proxies.Requests;

namespace BasisTheory.net.Proxies
{
    public interface IProxyClient
    {
        Proxy GetById(
            Guid proxyId,
            RequestOptions requestOptions = null);

        Proxy GetById(
            string proxyId,
            RequestOptions requestOptions = null);

        Task<Proxy> GetByIdAsync(
            Guid proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task<Proxy> GetByIdAsync(
            string proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Proxy> Get(ProxyGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Proxy>> GetAsync(
            ProxyGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Proxy Create(Proxy proxy, RequestOptions requestOptions = null);

        Task<Proxy> CreateAsync(
            Proxy proxy,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Proxy Update(Guid proxyId, Proxy proxy, RequestOptions requestOptions = null);
        Proxy Update(string proxyId, Proxy proxy, RequestOptions requestOptions = null);

        Task<Proxy> UpdateAsync(
            Guid proxyId,
            Proxy proxy,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task<Proxy> UpdateAsync(
            string proxyId,
            Proxy proxy,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid proxyId, RequestOptions requestOptions = null);
        void Delete(string proxyId, RequestOptions requestOptions = null);

        Task DeleteAsync(
            Guid proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            string proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class ProxyClient : BaseClient, IProxyClient
    {
        protected override string BasePath => "proxies";

        public ProxyClient(
            string apiKey = null,
            HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl,
            ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public Proxy GetById(
            Guid proxyId,
            RequestOptions requestOptions = null)
        {
            return GetById(proxyId.ToString(), requestOptions);
        }

        public Proxy GetById(
            string proxyId,
            RequestOptions requestOptions = null)
        {
            return Get<Proxy>($"{BasePath}/{proxyId}", null, requestOptions);
        }

        public async Task<Proxy> GetByIdAsync(
            Guid proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(proxyId.ToString(), requestOptions, cancellationToken);
        }

        public async Task<Proxy> GetByIdAsync(
            string proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Proxy>($"{BasePath}/{proxyId}", null, requestOptions, cancellationToken);
        }

        public PaginatedList<Proxy> Get(ProxyGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Proxy>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Proxy>> GetAsync(
            ProxyGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Proxy>>(BasePath, request, requestOptions, cancellationToken);
        }

        public Proxy Create(Proxy proxy, RequestOptions requestOptions = null)
        {
            return Post<Proxy>(BasePath, proxy, requestOptions);
        }

        public async Task<Proxy> CreateAsync(
            Proxy proxy,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Proxy>(BasePath, proxy, requestOptions, cancellationToken);
        }

        public Proxy Update(Guid proxyId, Proxy proxy, RequestOptions requestOptions = null)
        {
            return Update(proxyId.ToString(), proxy, requestOptions);
        }

        public Proxy Update(string proxyId, Proxy proxy, RequestOptions requestOptions = null)
        {
            return Put<Proxy>($"{BasePath}/{proxyId}", proxy, requestOptions);
        }

        public async Task<Proxy> UpdateAsync(
            Guid proxyId,
            Proxy proxy,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(proxyId.ToString(), proxy, requestOptions, cancellationToken);
        }

        public async Task<Proxy> UpdateAsync(
            string proxyId,
            Proxy proxy,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<Proxy>($"{BasePath}/{proxyId}", proxy, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid proxyId, RequestOptions requestOptions = null)
        {
            Delete(proxyId.ToString(), requestOptions);
        }

        public new void Delete(string proxyId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{proxyId}", requestOptions);
        }

        public async Task DeleteAsync(
            Guid proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync(proxyId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(
            string proxyId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{proxyId}", requestOptions, cancellationToken);
        }

    }
}

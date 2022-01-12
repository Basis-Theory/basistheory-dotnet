using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Tenants.Entities;

namespace BasisTheory.net.Tenants
{
    public interface ITenantClient
    {
        Tenant GetSelf(RequestOptions requestOptions = null);
        Task<Tenant> GetSelfAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        Tenant Update(Tenant tenant, RequestOptions requestOptions = null);
        Task<Tenant> UpdateAsync(Tenant tenant, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        void Delete(RequestOptions requestOptions = null);
        Task DeleteAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        TenantUsageReport GetTenantUsageReport(RequestOptions requestOptions = null);
        Task<TenantUsageReport> GetTenantUsageReportAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }

    public class TenantClient : BaseClient, ITenantClient
    {
        protected override string BasePath => "tenants";

        public TenantClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl, ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public Tenant GetSelf(RequestOptions requestOptions = null)
        {
            return Get<Tenant>($"{BasePath}/self", null, requestOptions);
        }

        public async Task<Tenant> GetSelfAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Tenant>($"{BasePath}/self", null, requestOptions, cancellationToken);
        }

        public Tenant Update(Tenant tenant, RequestOptions requestOptions = null)
        {
            return Put<Tenant>($"{BasePath}/self", tenant, requestOptions);
        }

        public async Task<Tenant> UpdateAsync(Tenant tenant, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PutAsync<Tenant>($"{BasePath}/self", tenant, requestOptions, cancellationToken);
        }

        public void Delete(RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/self", requestOptions);
        }

        public async Task DeleteAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/self", requestOptions, cancellationToken);
        }

        public TenantUsageReport GetTenantUsageReport(RequestOptions requestOptions = null)
        {
            return Get<TenantUsageReport>($"{BasePath}/self/reports/usage", null, requestOptions);
        }

        public async Task<TenantUsageReport> GetTenantUsageReportAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<TenantUsageReport>($"{BasePath}/self/reports/usage", null, requestOptions, cancellationToken);
        }
    }
}

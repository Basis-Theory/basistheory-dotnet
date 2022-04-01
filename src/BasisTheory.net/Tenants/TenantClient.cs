using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tenants.Entities;
using BasisTheory.net.Tenants.Requests;

namespace BasisTheory.net.Tenants
{
    public interface ITenantClient
    {
        Tenant GetSelf(RequestOptions requestOptions = null);
        Task<Tenant> GetSelfAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        Tenant Update(Tenant tenant, RequestOptions requestOptions = null);

        Task<Tenant> UpdateAsync(Tenant tenant, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(RequestOptions requestOptions = null);
        Task DeleteAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        TenantUsageReport GetTenantUsageReport(RequestOptions requestOptions = null);

        Task<TenantUsageReport> GetTenantUsageReportAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class TenantClient : BaseClient, ITenantClient
    {
        protected override string BasePath => "tenants";

        public TenantClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl,
            ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public Tenant GetSelf(RequestOptions requestOptions = null)
        {
            return Get<Tenant>($"{BasePath}/self", null, requestOptions);
        }

        public async Task<Tenant> GetSelfAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Tenant>($"{BasePath}/self", null, requestOptions, cancellationToken);
        }

        public Tenant Update(Tenant tenant, RequestOptions requestOptions = null)
        {
            return Put<Tenant>($"{BasePath}/self", tenant, requestOptions);
        }

        public async Task<Tenant> UpdateAsync(Tenant tenant, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<Tenant>($"{BasePath}/self", tenant, requestOptions, cancellationToken);
        }

        public void Delete(RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/self", requestOptions);
        }

        public async Task DeleteAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/self", requestOptions, cancellationToken);
        }

        public TenantUsageReport GetTenantUsageReport(RequestOptions requestOptions = null)
        {
            return Get<TenantUsageReport>($"{BasePath}/self/reports/usage", null, requestOptions);
        }

        public async Task<TenantUsageReport> GetTenantUsageReportAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<TenantUsageReport>($"{BasePath}/self/reports/usage", null, requestOptions,
                cancellationToken);
        }

        // TODO: needs tests
        public TenantInvitation CreateInvitation(TenantInvitation tenantInvitation,
            RequestOptions requestOptions = null)
        {
            return Post<TenantInvitation>($"{BasePath}/self/invitations", tenantInvitation, requestOptions);
        }

        public async Task<TenantInvitation> CreateInvitationAsync(TenantInvitation tenantInvitation,
            RequestOptions requestOptions = null)
        {
            return await PostAsync<TenantInvitation>($"{BasePath}/self/invitations", tenantInvitation, requestOptions);
        }

        // TODO: needs tests
        public TenantInvitation ResendInvitation(Guid tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return ResendInvitation(tenantInvitationId.ToString(), requestOptions);
        }

        public TenantInvitation ResendInvitation(string tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return Post<TenantInvitation>($"{BasePath}/self/invitations/{tenantInvitationId}/resend", null,
                requestOptions);
        }

        public async Task<TenantInvitation> ResendInvitationAsync(Guid tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return await ResendInvitationAsync(tenantInvitationId.ToString(), requestOptions);
        }

        public async Task<TenantInvitation> ResendInvitationAsync(string tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return await PostAsync<TenantInvitation>($"{BasePath}/self/invitations/{tenantInvitationId}/resend", null,
                requestOptions);
        }

        // TODO: needs tests
        public PaginatedList<TenantInvitation> GetInvitations(TenantInvitationsGetRequest tenantInvitationsGetRequest,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<TenantInvitation>>($"{BasePath}/self/invitations", tenantInvitationsGetRequest,
                requestOptions);
        }

        public async Task<PaginatedList<TenantInvitation>> GetInvitationsAsync(
            TenantInvitationsGetRequest tenantInvitationsGetRequest,
            RequestOptions requestOptions = null)
        {
            return await GetAsync<PaginatedList<TenantInvitation>>($"{BasePath}/self/invitations",
                tenantInvitationsGetRequest,
                requestOptions);
        }

        // TODO: needs tests
        public TenantInvitation GetInvitationById(Guid tenantInvitationId, TenantsGetByIdRequest tenantsGetByIdRequest,
            RequestOptions requestOptions = null)
        {
            return GetInvitationById(tenantInvitationId.ToString(), tenantsGetByIdRequest, requestOptions);
        }

        public TenantInvitation GetInvitationById(string tenantInvitationId,
            TenantsGetByIdRequest tenantsGetByIdRequest,
            RequestOptions requestOptions = null)
        {
            return Get<TenantInvitation>($"{BasePath}/self/invitations/{tenantInvitationId}", tenantsGetByIdRequest,
                requestOptions);
        }

        public async Task<TenantInvitation> GetInvitationByIdAsync(
            Guid tenantInvitationId, TenantsGetByIdRequest tenantsGetByIdRequest,
            RequestOptions requestOptions = null)
        {
            return await GetInvitationByIdAsync(tenantInvitationId.ToString(),
                tenantsGetByIdRequest,
                requestOptions);
        }

        public async Task<TenantInvitation> GetInvitationByIdAsync(
            string tenantInvitationId, TenantsGetByIdRequest tenantsGetByIdRequest,
            RequestOptions requestOptions = null)
        {
            return await GetAsync<TenantInvitation>($"{BasePath}/self/invitations/{tenantInvitationId}",
                tenantsGetByIdRequest,
                requestOptions);
        }

        // TODO: needs tests
        public void DeleteInvitation(Guid tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            DeleteInvitation(tenantInvitationId.ToString(), requestOptions);
        }

        public void DeleteInvitation(string tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/self/invitations/{tenantInvitationId}", requestOptions);
        }

        public async Task DeleteInvitationAsync(
            Guid tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            await DeleteInvitationAsync(tenantInvitationId.ToString(),
                requestOptions);
        }

        public async Task DeleteInvitationAsync(
            string tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            await DeleteAsync($"{BasePath}/self/invitations/{tenantInvitationId}",
                requestOptions);
        }

        // TODO: needs tests
        public PaginatedList<TenantMember> GetMembers(TenantMemberGetRequest tenantMembersGetRequest,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<TenantMember>>($"{BasePath}/self/members", tenantMembersGetRequest,
                requestOptions);
        }

        public async Task<PaginatedList<TenantMember>> GetMembersAsync(
            TenantMemberGetRequest tenantMembersGetRequest,
            RequestOptions requestOptions = null)
        {
            return await GetAsync<PaginatedList<TenantMember>>($"{BasePath}/self/members",
                tenantMembersGetRequest,
                requestOptions);
        }

        // TODO: needs tests
        public void DeleteMember(Guid tenantMemberId,
            RequestOptions requestOptions = null)
        {
            DeleteMember(tenantMemberId.ToString(), requestOptions);
        }

        public void DeleteMember(string tenantMemberId,
            RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/self/members/{tenantMemberId}", requestOptions);
        }

        public async Task DeleteMemberAsync(
            Guid tenantMemberId,
            RequestOptions requestOptions = null)
        {
            await DeleteMemberAsync(tenantMemberId.ToString(),
                requestOptions);
        }

        public async Task DeleteMemberAsync(
            string tenantMemberId,
            RequestOptions requestOptions = null)
        {
            await DeleteAsync($"{BasePath}/self/members/{tenantMemberId}",
                requestOptions);
        }
    }
}

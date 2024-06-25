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

        Tenant Update(TenantUpdateRequest tenant, RequestOptions requestOptions = null);

        Task<Tenant> UpdateAsync(TenantUpdateRequest tenant, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(RequestOptions requestOptions = null);
        Task DeleteAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        TenantUsageReport GetTenantUsageReport(RequestOptions requestOptions = null);

        Task<TenantUsageReport> GetTenantUsageReportAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        TenantInvitation CreateInvitation(TenantInvitation tenantInvitation,
            RequestOptions requestOptions = null);

        Task<TenantInvitation> CreateInvitationAsync(TenantInvitation tenantInvitation,
            RequestOptions requestOptions = null);

        TenantInvitation ResendInvitation(Guid tenantInvitationId,
            RequestOptions requestOptions = null);

        TenantInvitation ResendInvitation(string tenantInvitationId,
            RequestOptions requestOptions = null);

        Task<TenantInvitation> ResendInvitationAsync(Guid tenantInvitationId,
            RequestOptions requestOptions = null);

        Task<TenantInvitation> ResendInvitationAsync(string tenantInvitationId,
            RequestOptions requestOptions = null);

        PaginatedList<TenantInvitation> GetInvitations(TenantInvitationsGetRequest tenantInvitationsGetRequest = null,
            RequestOptions requestOptions = null);

        Task<PaginatedList<TenantInvitation>> GetInvitationsAsync(
            TenantInvitationsGetRequest tenantInvitationsGetRequest = null,
            RequestOptions requestOptions = null);

        TenantInvitation GetInvitationById(Guid tenantInvitationId,
            RequestOptions requestOptions = null);

        TenantInvitation GetInvitationById(string tenantInvitationId,
            RequestOptions requestOptions = null);

        Task<TenantInvitation> GetInvitationByIdAsync(Guid tenantInvitationId,
            RequestOptions requestOptions = null);

        Task<TenantInvitation> GetInvitationByIdAsync(string tenantInvitationId,
            RequestOptions requestOptions = null);

        void DeleteInvitation(Guid tenantInvitationId,
            RequestOptions requestOptions = null);

        void DeleteInvitation(string tenantInvitationId,
            RequestOptions requestOptions = null);

        Task DeleteInvitationAsync(
            Guid tenantInvitationId,
            RequestOptions requestOptions = null);

        Task DeleteInvitationAsync(
            string tenantInvitationId,
            RequestOptions requestOptions = null);

        PaginatedList<TenantMember> GetMembers(TenantMemberGetRequest tenantMembersGetRequest = null,
            RequestOptions requestOptions = null);

        Task<PaginatedList<TenantMember>> GetMembersAsync(
            TenantMemberGetRequest tenantMembersGetRequest = null,
            RequestOptions requestOptions = null);

        TenantMember UpdateMember(Guid tenantMemberId,
            TenantMemberUpdateRequest request,
            RequestOptions requestOptions = null);

        TenantMember UpdateMember(string tenantMemberId,
            TenantMemberUpdateRequest request,
            RequestOptions requestOptions = null);

        Task<TenantMember> UpdateMemberAsync(
            Guid tenantMemberId,
            TenantMemberUpdateRequest request,
            RequestOptions requestOptions = null);

        Task<TenantMember> UpdateMemberAsync(
            string tenantMemberId,
            TenantMemberUpdateRequest request,
            RequestOptions requestOptions = null);

        void DeleteMember(Guid tenantMemberId,
            RequestOptions requestOptions = null);

        void DeleteMember(string tenantMemberId,
            RequestOptions requestOptions = null);

        Task DeleteMemberAsync(
            Guid tenantMemberId,
            RequestOptions requestOptions = null);

        Task DeleteMemberAsync(
            string tenantMemberId,
            RequestOptions requestOptions = null);
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

        public Tenant Update(TenantUpdateRequest tenant, RequestOptions requestOptions = null)
        {
            return Put<Tenant>($"{BasePath}/self", tenant, requestOptions);
        }

        public async Task<Tenant> UpdateAsync(TenantUpdateRequest tenant, RequestOptions requestOptions = null,
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

        public PaginatedList<TenantInvitation> GetInvitations(
            TenantInvitationsGetRequest tenantInvitationsGetRequest = null,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<TenantInvitation>>($"{BasePath}/self/invitations", tenantInvitationsGetRequest,
                requestOptions);
        }

        public async Task<PaginatedList<TenantInvitation>> GetInvitationsAsync(
            TenantInvitationsGetRequest tenantInvitationsGetRequest = null,
            RequestOptions requestOptions = null)
        {
            return await GetAsync<PaginatedList<TenantInvitation>>($"{BasePath}/self/invitations",
                tenantInvitationsGetRequest,
                requestOptions);
        }

        public TenantInvitation GetInvitationById(Guid tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return GetInvitationById(tenantInvitationId.ToString(), requestOptions);
        }

        public TenantInvitation GetInvitationById(string tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return Get<TenantInvitation>($"{BasePath}/self/invitations/{tenantInvitationId}", null,
                requestOptions);
        }

        public async Task<TenantInvitation> GetInvitationByIdAsync(
            Guid tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return await GetInvitationByIdAsync(tenantInvitationId.ToString(),
                requestOptions);
        }

        public async Task<TenantInvitation> GetInvitationByIdAsync(
            string tenantInvitationId,
            RequestOptions requestOptions = null)
        {
            return await GetAsync<TenantInvitation>($"{BasePath}/self/invitations/{tenantInvitationId}",
                null,
                requestOptions);
        }

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

        public PaginatedList<TenantMember> GetMembers(TenantMemberGetRequest tenantMembersGetRequest = null,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<TenantMember>>($"{BasePath}/self/members", tenantMembersGetRequest,
                requestOptions);
        }

        public async Task<PaginatedList<TenantMember>> GetMembersAsync(
            TenantMemberGetRequest tenantMembersGetRequest = null,
            RequestOptions requestOptions = null)
        {
            return await GetAsync<PaginatedList<TenantMember>>($"{BasePath}/self/members",
                tenantMembersGetRequest,
                requestOptions);
        }

        public TenantMember UpdateMember(Guid tenantMemberId, TenantMemberUpdateRequest request, RequestOptions requestOptions = null)
        {
            return UpdateMember(tenantMemberId.ToString(), request, requestOptions);
        }

        public TenantMember UpdateMember(string tenantMemberId, TenantMemberUpdateRequest request, RequestOptions requestOptions = null)
        {
            return Put<TenantMember>($"{BasePath}/self/members/{tenantMemberId}", request, requestOptions);
        }

        public async Task<TenantMember> UpdateMemberAsync(Guid tenantMemberId, TenantMemberUpdateRequest request, RequestOptions requestOptions = null)
        {
            return await UpdateMemberAsync(tenantMemberId.ToString(), request, requestOptions);
        }

        public async Task<TenantMember> UpdateMemberAsync(string tenantMemberId, TenantMemberUpdateRequest request, RequestOptions requestOptions = null)
        {
            return await PutAsync<TenantMember>($"{BasePath}/self/members/{tenantMemberId}", request, requestOptions);
        }

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

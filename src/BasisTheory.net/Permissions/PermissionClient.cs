using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Permissions.Entities;
using BasisTheory.net.Permissions.Requests;

namespace BasisTheory.net.Permissions
{
    public interface IPermissionClient
    {
        List<Permission> Get(PermissionGetRequest request = null, RequestOptions requestOptions = null);
        Task<List<Permission>> GetAsync(PermissionGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class PermissionClient : BaseClient, IPermissionClient
    {
        protected override string BasePath => "permissions";

        public PermissionClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl, ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public List<Permission> Get(PermissionGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<List<Permission>>(BasePath, request, requestOptions);
        }

        public async Task<List<Permission>> GetAsync(PermissionGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<Permission>>(BasePath, request, requestOptions, cancellationToken);
        }
    }
}

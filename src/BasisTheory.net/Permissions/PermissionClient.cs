using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Permissions.Entities;

namespace BasisTheory.net.Permissions
{
    public interface IPermissionClient
    {
        List<Permission> Get(RequestOptions requestOptions = null);

        Task<List<Permission>> GetAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class PermissionClient : BaseClient, IPermissionClient
    {
        protected override string BasePath => "permissions";

        public PermissionClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public List<Permission> Get(RequestOptions requestOptions = null)
        {
            return Get<List<Permission>>(BasePath, null, requestOptions);
        }

        public async Task<List<Permission>> GetAsync(RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<Permission>>(BasePath, null, requestOptions, cancellationToken);
        }
    }
}

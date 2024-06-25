using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Roles.Entities;

namespace BasisTheory.net.Roles;

public interface IRolesClient
{
    List<Role> Get(RequestOptions requestOptions = null);
    Task<List<Role>> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
}

public class RolesClient : BaseClient, IRolesClient
{
    protected override string BasePath => "roles";
    
    public RolesClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl, ApplicationInfo appInfo = null) :
        base(apiKey, httpClient, apiBase, appInfo)
    { }

    public List<Role> Get(RequestOptions requestOptions = null) =>
        Get<List<Role>>($"{BasePath}", null, requestOptions);

    public Task<List<Role>> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
        GetAsync<List<Role>>($"{BasePath}", null, requestOptions, cancellationToken);
}
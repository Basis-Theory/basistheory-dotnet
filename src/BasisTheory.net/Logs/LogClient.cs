using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Logs.Entities;
using BasisTheory.net.Logs.Requests;

namespace BasisTheory.net.Logs;

public interface ILogClient
{
    PaginatedList<Log> Get(LogGetRequest request = null, RequestOptions requestOptions = null);
    Task<PaginatedList<Log>> GetAsync(LogGetRequest request = null,
        RequestOptions requestOptions = null,
        CancellationToken cancellationToken = default);
}

public class LogClient : BaseClient, ILogClient
{
    protected override string BasePath => "logs";

    public LogClient(string apiKey = null, HttpClient httpClient = null,
        string apiBase = DefaultBaseUrl, ApplicationInfo appInfo = null) :
        base(apiKey, httpClient, apiBase, appInfo)
    {
    }

    public PaginatedList<Log> Get(LogGetRequest request = null, RequestOptions requestOptions = null)
    {
        return Get<PaginatedList<Log>>(BasePath, request, requestOptions);
    }

    public async Task<PaginatedList<Log>> GetAsync(LogGetRequest request = null, RequestOptions requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        return await GetAsync<PaginatedList<Log>>(BasePath, request, requestOptions, cancellationToken);
    }
}
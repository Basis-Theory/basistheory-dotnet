namespace BasisTheory.net.Common.Requests;

public abstract class PaginatedGetRequest : GetRequest
{
    public int? Page { get; set; }

    public string? Start { get; set; }

    public int? PageSize { get; set; }
}
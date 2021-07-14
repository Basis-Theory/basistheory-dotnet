using Microsoft.AspNetCore.Mvc;

namespace BasisTheory.net.Common.Requests
{
    public abstract class PaginatedGetRequest : GetRequest
    {
        [FromQuery(Name = "page")]
        public int? Page { get; set; }

        [FromQuery(Name = "size")]
        public int? PageSize { get; set; }
    }
}

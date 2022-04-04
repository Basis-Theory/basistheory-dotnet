using System.Collections.Generic;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tenants.Requests
{
    public class TenantInvitationsGetRequest : PaginatedGetRequest
    {
        public string Status { get; set; }

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            if(!string.IsNullOrWhiteSpace(Status))
                queryParts.Add($"status={Status}");

            return string.Join("&", queryParts);
        }
    }
}

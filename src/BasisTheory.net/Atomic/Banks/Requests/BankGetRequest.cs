using System.Collections.Generic;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Atomic.Banks.Requests
{
    public class BankGetRequest : PaginatedGetRequest
    {
        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            return string.Join("&", queryParts);
        }
    }
}

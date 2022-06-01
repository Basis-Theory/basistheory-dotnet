using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Proxies.Requests
{
    public class ProxyGetRequest : PaginatedGetRequest
    {
        public List<Guid> ProxyIds { get; set; } = new List<Guid>();

        public string Name { get; set; }

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            if (ProxyIds?.Any() ?? false)
                queryParts.AddRange(ProxyIds.Select(proxyId => $"id={proxyId}"));

            if (!string.IsNullOrWhiteSpace(Name))
                queryParts.Add($"name={Name}");

            return string.Join("&", queryParts);
        }
    }
}

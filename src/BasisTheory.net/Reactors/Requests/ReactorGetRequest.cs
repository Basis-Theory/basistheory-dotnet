using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Reactors.Requests
{
    public class ReactorGetRequest : PaginatedGetRequest
    {
        public List<Guid> ReactorIds { get; set; } = new List<Guid>();

        public string Name { get; set; }

        public string SourceTokenType { get; set; }

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            if (ReactorIds?.Any() ?? false)
                queryParts.AddRange(ReactorIds.Select(exchangeId => $"id={exchangeId}"));

            if(!string.IsNullOrWhiteSpace(Name))
                queryParts.Add($"name={Name}");

            if(!string.IsNullOrWhiteSpace(SourceTokenType))
                queryParts.Add($"source_token_type={SourceTokenType}");

            return string.Join("&", queryParts);
        }
    }
}

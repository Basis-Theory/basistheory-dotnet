using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Exchanges.Requests
{
    public class ExchangeGetRequest : PaginatedGetRequest
    {
        public List<Guid> ExchangeIds { get; set; } = new List<Guid>();

        public string Name { get; set; }

        public string SourceTokenType { get; set; }

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            if (ExchangeIds?.Any() ?? false)
                queryParts.AddRange(ExchangeIds.Select(exchangeId => $"id={exchangeId}"));

            if(!string.IsNullOrWhiteSpace(Name))
                queryParts.Add($"name={Name}");

            if(!string.IsNullOrWhiteSpace(SourceTokenType))
                queryParts.Add($"source_token_type={SourceTokenType}");

            return string.Join("&", queryParts);
        }
    }
}

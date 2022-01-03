using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenGetRequest : PaginatedGetRequest
    {
        public List<Guid> TokenIds { get; set; } = new List<Guid>();
        public List<string> Types { get; set; } = new List<string>();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            queryParts.AddRange(Types.Select(type => $"type={type}"));

            if (TokenIds?.Any() ?? false)
                queryParts.AddRange(TokenIds.Select(tokenId => $"id={tokenId}"));

            return string.Join("&", queryParts);
        }
    }
}

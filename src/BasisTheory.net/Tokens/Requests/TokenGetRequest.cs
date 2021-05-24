using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenGetRequest : PaginatedGetRequest
    {
        public bool Decrypt { get; set; } = false;
        public List<string> DecryptTypes { get; set; } = new List<string>();
        public List<Guid> TokenIds { get; set; } = new List<Guid>();
        public List<string> Types { get; set; } = new List<string>();
        public bool? Children { get; set; }
        public List<string> ChildrenTypes { get; set; } = new List<string>();

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

            if (DecryptTypes.Any())
                queryParts.AddRange(DecryptTypes.Select(decryptType => $"decrypt_type={decryptType}"));

            if (Children.HasValue)
                queryParts.Add($"children={Children.Value.ToString().ToLower()}");

            if (ChildrenTypes.Any())
                queryParts.AddRange(ChildrenTypes.Select(childrenType => $"children_type={childrenType}"));

            return string.Join("&", queryParts);
        }
    }
}

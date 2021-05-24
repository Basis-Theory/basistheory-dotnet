using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenGetRequest : PaginatedGetRequest
    {
        public List<string> Types { get; } = new();
        public bool Children { get; set; }
        public List<string> ChildrenTypes { get; } = new();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            queryParts.AddRange(Types.Select(type => $"type={type}"));

            if (Children)
            {
                queryParts.Add("children=true");
                queryParts.AddRange(ChildrenTypes.Select(childrenType => $"children_type={childrenType}"));
            }

            return string.Join("&", queryParts);
        }
    }
}

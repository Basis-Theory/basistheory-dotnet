using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenGetByIdRequest : GetRequest
    {
        public bool? Children { get; set; }
        public List<string> ChildrenTypes { get; set; } = new List<string>();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Children.HasValue)
                queryParts.Add($"children={Children.Value.ToString().ToLower()}");

            if (ChildrenTypes.Any())
                queryParts.AddRange(ChildrenTypes.Select(childrenType => $"children_type={childrenType}"));

            return string.Join("&", queryParts);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenGetByIdRequest : GetRequest
    {
        public bool Children { get; set; }
        public List<string> ChildrenTypes { get; } = new();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();
            if (!Children) return null;

            queryParts.Add("children=true");
            queryParts.AddRange(ChildrenTypes.Select(childrenType => $"children_type={childrenType}"));

            return string.Join("&", queryParts);
        }
    }
}

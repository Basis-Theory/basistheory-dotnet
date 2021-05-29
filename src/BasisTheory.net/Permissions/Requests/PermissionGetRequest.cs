using System.Collections.Generic;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Permissions.Requests
{
    public class PermissionGetRequest : GetRequest
    {
        public string ApplicationType { get; set; }

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (!string.IsNullOrEmpty(ApplicationType))
                queryParts.Add($"application_type={ApplicationType}");

            return string.Join("&", queryParts);
        }
    }
}

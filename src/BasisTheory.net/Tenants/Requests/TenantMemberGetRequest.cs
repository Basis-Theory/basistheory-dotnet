using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Tenants.Requests
{
    public class TenantMemberGetRequest : PaginatedGetRequest
    {
        public List<Guid> MemberUserIds { get; set; } = new List<Guid>();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            if (MemberUserIds?.Any() ?? false)
                queryParts.AddRange(MemberUserIds.Select(memberUserId => $"user_id={memberUserId}"));

            return string.Join("&", queryParts);
        }
    }
}

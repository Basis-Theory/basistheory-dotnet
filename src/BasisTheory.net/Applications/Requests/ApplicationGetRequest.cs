using System;
using System.Collections.Generic;
using System.Linq;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Applications.Requests
{
    public class ApplicationGetRequest : PaginatedGetRequest
    {
        public List<Guid> ApplicationIds { get; set; } = new List<Guid>();

        public override string BuildQuery()
        {
            var queryParts = new List<string>();

            if (Page.HasValue)
                queryParts.Add($"page={Page}");

            if (PageSize.HasValue)
                queryParts.Add($"size={PageSize}");

            if (ApplicationIds.Any())
                queryParts.AddRange(ApplicationIds.Select(applicationId => $"id={applicationId}"));

            return string.Join("&", queryParts);
        }
    }
}

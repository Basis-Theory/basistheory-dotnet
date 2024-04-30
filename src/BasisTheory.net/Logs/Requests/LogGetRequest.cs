using System;
using System.Collections.Generic;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.Logs.Requests;

public class LogGetRequest : PaginatedGetRequest
{
    public string EntityType { get; set; }

    public string EntityId { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public override string BuildQuery()
    {
        var queryParts = new List<string>();

        if (Start != null)
            queryParts.Add($"start={Start}");

        if (PageSize.HasValue)
            queryParts.Add($"size={PageSize}");

        if (!string.IsNullOrWhiteSpace(EntityType))
            queryParts.Add($"entity_type={EntityType}");

        if (!string.IsNullOrWhiteSpace(EntityId))
            queryParts.Add($"entity_id={EntityId}");

        if (StartDate.HasValue)
            queryParts.Add($"start_date={StartDate.Value:s}");

        if (EndDate.HasValue)
            queryParts.Add($"end_date={EndDate.Value:s}");

        return string.Join("&", queryParts);
    }
}
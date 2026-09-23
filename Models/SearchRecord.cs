using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record SearchRecord
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("document")]
    public Document? Document { get; init; }

    /// <summary>
    /// Only the requests that matched in the run that emitted this record. A record
    /// is emitted once, on first sight, so a request that would match it in a later
    /// run never attaches to it.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("matched_requests")]
    public IReadOnlyList<SearchRequestRef>? MatchedRequests { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record ListRunsResponse
{
    /// <summary>
    /// True when limit cut the page short.
    /// </summary>
    [JsonPropertyName("has_more")]
    public bool? HasMore { get; init; } = false;

    /// <summary>
    /// Newest first by default, so \[0\] is the latest run. Page back with
    /// before = runs\[last\].run_id; pass sort = SORT_ORDER_ASC to walk forward
    /// instead, and page with since = runs\[last\].run_id.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("runs")]
    public IReadOnlyList<Run>? Runs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

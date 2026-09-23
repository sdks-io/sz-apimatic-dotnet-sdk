using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// List-runs response: one page of runs.
/// </summary>
public record ListAgentRunsResponse
{
    /// <summary>
    /// Cursor to the next page. Unset on the last page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("next")]
    public string? Next { get; init; }

    /// <summary>
    /// The page's runs, newest first.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("runs")]
    public IReadOnlyList<AgentRun>? Runs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

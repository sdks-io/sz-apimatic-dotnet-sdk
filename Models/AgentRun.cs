using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

/// <summary>
/// An agent run.
/// </summary>
public record AgentRun
{
    /// <summary>
    /// When the run reached a terminal state. Unset until then.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; init; }

    /// <summary>
    /// When the run was created, as an ISO 8601 timestamp.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; } = "";

    /// <summary>
    /// Unique run id.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; } = "";

    /// <summary>
    /// Object type, always "agent.run".
    /// </summary>
    [JsonPropertyName("object")]
    public string? Object { get; init; } = "";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("output")]
    public AgentRunOutput2? Output { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("request")]
    public AgentRunRequest2? Request { get; init; }

    /// <summary>
    /// When the run started. Unset while pending.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("started_at")]
    public string? StartedAt { get; init; }

    [JsonPropertyName("status")]
    public AgentRunStatus2? Status { get; init; } = AgentRunStatus2.Pending;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stop_reason")]
    public AgentRunStopReason2? StopReason { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

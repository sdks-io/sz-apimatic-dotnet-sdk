using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// The request a run was created with.
/// </summary>
public record AgentRunRequest
{
    /// <summary>
    /// The effort level the run executes at: the request's <c>effort</c>, or the
    /// default level when it named none.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("effort")]
    public string? Effort { get; init; }

    /// <summary>
    /// The request's <c>output_schema</c>, when one was given. On gRPC the object is
    /// JSON-encoded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("output_schema")]
    public object? OutputSchema { get; init; }

    /// <summary>
    /// The natural-language question.
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

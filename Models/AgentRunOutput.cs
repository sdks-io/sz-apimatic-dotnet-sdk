using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// A run's output.
/// </summary>
public record AgentRunOutput
{
    /// <summary>
    /// Per-field citations for <c>structured</c>. Empty when there is no structured
    /// output.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("grounding")]
    public IReadOnlyList<AgentRunGrounding>? Grounding { get; init; }

    /// <summary>
    /// The sources cited by <c>text</c> or <c>grounding</c>, numbered in order of first
    /// citation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sources")]
    public IReadOnlyList<AgentRunSource>? Sources { get; init; }

    /// <summary>
    /// Structured result shaped by the request's <c>output_schema</c>. Unset when the
    /// request had none. Fields that could not be grounded are expected to be
    /// null. On gRPC the object is JSON-encoded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("structured")]
    public object? Structured { get; init; }

    /// <summary>
    /// Cited markdown report. Inline <c>\[n\]</c> markers cite the entry of <c>sources</c>
    /// whose <c>id</c> is <c>n</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

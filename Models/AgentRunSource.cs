using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

/// <summary>
/// One source a run cited.
/// </summary>
public record AgentRunSource
{
    /// <summary>
    /// Identifier within the run, cited as <c>\[id\]</c> in <c>text</c> and as <c>source_id</c>
    /// in <c>grounding</c>.
    /// </summary>
    [JsonPropertyName("id")]
    [Minimum(0)]
    public int? Id { get; init; } = 0;

    /// <summary>
    /// URL of the source document.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

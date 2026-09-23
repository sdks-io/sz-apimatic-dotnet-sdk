using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

/// <summary>
/// One citation supporting a grounded field.
/// </summary>
public record AgentRunCitation
{
    /// <summary>
    /// <c>id</c> of the entry in <c>sources</c> this citation points at.
    /// </summary>
    [JsonPropertyName("source_id")]
    [Minimum(0)]
    public int? SourceId { get; init; } = 0;

    /// <summary>
    /// URL of the cited document.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

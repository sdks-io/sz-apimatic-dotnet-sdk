using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// Citations for one field of <c>output.structured</c>.
/// </summary>
public record AgentRunGrounding
{
    /// <summary>
    /// Citations supporting this field's value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("citations")]
    public IReadOnlyList<AgentRunCitation>? Citations { get; init; }

    /// <summary>
    /// Dot-notation path into the structured output, e.g. "companies.0.ceo".
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

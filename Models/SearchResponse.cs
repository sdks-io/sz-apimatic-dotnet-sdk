using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record SearchResponse
{
    /// <summary>
    /// Documents that are most relevant to the query
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("documents")]
    public IReadOnlyList<Document>? Documents { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

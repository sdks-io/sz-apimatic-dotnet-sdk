using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record SearchRequestRef
{
    /// <summary>
    /// The request's query text, carried here so a record can be rendered without
    /// a second lookup.
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; init; } = "";

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

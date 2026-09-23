using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

public record Record
{
    [JsonPropertyName("search_result")]
    public required SearchRecord SearchResult { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("first_seen_at")]
    public string? FirstSeenAt { get; init; }

    [JsonPropertyName("record_id")]
    public string? RecordId { get; init; } = "0";

    [JsonPropertyName("run_id")]
    public string? RunId { get; init; } = "0";

    [JsonPropertyName("type")]
    public RecordType Type { get; init; } = RecordType.SearchResult;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

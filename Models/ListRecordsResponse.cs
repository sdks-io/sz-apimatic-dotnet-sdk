using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record ListRecordsResponse
{
    /// <summary>
    /// True when limit or the byte budget cut the page short. Page forward with
    /// since = records\[last\].record_id.
    /// </summary>
    [JsonPropertyName("has_more")]
    public bool? HasMore { get; init; } = false;

    /// <summary>
    /// Oldest first. A short page is normal: a page ends at limit or at a byte
    /// budget, whichever binds first.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("records")]
    public IReadOnlyList<Record>? Records { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

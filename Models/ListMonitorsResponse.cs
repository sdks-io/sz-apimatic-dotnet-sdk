using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record ListMonitorsResponse
{
    /// <summary>
    /// True when limit or the byte budget cut the page short. Page forward with
    /// before = monitors\[last\].monitor_id.
    /// </summary>
    [JsonPropertyName("has_more")]
    public bool? HasMore { get; init; } = false;

    /// <summary>
    /// Newest first. A short page is normal: a page ends at limit or at a byte
    /// budget, whichever binds first. A monitor carries its whole request list,
    /// so a count alone cannot bound the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monitors")]
    public IReadOnlyList<MonitorModel>? Monitors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

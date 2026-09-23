using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record UpdateMonitorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monitor")]
    public MonitorModel? Monitor { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

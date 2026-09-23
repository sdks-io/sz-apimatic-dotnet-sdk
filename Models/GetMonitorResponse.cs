using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

public record GetMonitorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monitor")]
    public MonitorModel? Monitor { get; init; }

    [JsonPropertyName("run_state")]
    public RunState2 RunState { get; init; } = RunState2.Idle;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

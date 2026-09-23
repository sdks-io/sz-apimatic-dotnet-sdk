using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

public record MonitorModel
{
    [JsonPropertyName("cadence")]
    public required string Cadence { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    [JsonPropertyName("monitor_id")]
    public string? MonitorId { get; init; } = "";

    [JsonPropertyName("name")]
    public string? Name { get; init; } = "";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_requests")]
    public IReadOnlyList<MonitorSearchRequest>? SearchRequests { get; init; }

    [JsonPropertyName("status")]
    public MonitorStatus Status { get; init; } = MonitorStatus.Active;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("webhook")]
    public Webhook? Webhook { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

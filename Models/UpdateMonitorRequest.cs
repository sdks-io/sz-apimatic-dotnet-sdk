using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

public record UpdateMonitorRequest
{
    [JsonPropertyName("cadence")]
    public required string Cadence { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    [JsonPropertyName("monitor_id")]
    public string? MonitorId { get; init; } = "";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Replaces the list wholesale when set. An empty list is read as "not set"
    /// and keeps the current requests. A request keeps its id and its health when
    /// every field of its body is unchanged.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_requests")]
    public IReadOnlyList<SearchRequest>? SearchRequests { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public MonitorStatus? Status { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("webhook")]
    public Webhook1? Webhook { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

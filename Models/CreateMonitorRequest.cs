using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

public record CreateMonitorRequest
{
    [JsonPropertyName("cadence")]
    public required string Cadence { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    /// <summary>
    /// Unique per org among live monitors; a deleted monitor's name becomes
    /// available again. At most 512 bytes of UTF-8.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; } = "";

    /// <summary>
    /// At least one, at most 1000. Every request runs on every run. A request
    /// with an <c>api_key</c> set, a blank <c>query</c>, or a body identical to another in
    /// the list is rejected.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_requests")]
    public IReadOnlyList<SearchRequest>? SearchRequests { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public MonitorStatus2? Status { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("webhook")]
    public Webhook? Webhook { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

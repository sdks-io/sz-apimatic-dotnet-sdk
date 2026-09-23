using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

/// <summary>
/// A search request stored on a monitor, with its server-assigned id.
/// </summary>
public record MonitorSearchRequest
{
    /// <summary>
    /// Consecutive failed runs for this request.
    /// </summary>
    [JsonPropertyName("consecutive_failures")]
    [Minimum(0)]
    public long? ConsecutiveFailures { get; init; } = 0L;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_success_at")]
    public string? LastSuccessAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("request")]
    public SearchRequest? Request { get; init; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

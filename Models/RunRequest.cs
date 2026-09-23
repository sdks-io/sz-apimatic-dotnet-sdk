using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

/// <summary>
/// One run's outcome for one search request.
/// </summary>
public record RunRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; init; }

    [JsonPropertyName("new_records")]
    [Minimum(0)]
    public long? NewRecords { get; init; } = 0L;

    /// <summary>
    /// Why the request failed, empty when it succeeded. Not machine-readable.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; init; } = "";

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; } = "";

    [JsonPropertyName("results_returned")]
    [Minimum(0)]
    public long? ResultsReturned { get; init; } = 0L;

    [JsonPropertyName("status")]
    public RequestStatus Status { get; init; } = RequestStatus.Ok;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

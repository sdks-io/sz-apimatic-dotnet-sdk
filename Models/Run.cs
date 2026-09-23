using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

public record Run
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; init; }

    /// <summary>
    /// The lowest <c>record_id</c> this run produced. Records are not contiguous; use
    /// <c>record_count</c> for the count.
    /// </summary>
    [JsonPropertyName("first_record_id")]
    public string? FirstRecordId { get; init; } = "0";

    /// <summary>
    /// The highest <c>record_id</c> this run produced. Records are not contiguous; use
    /// <c>record_count</c> for the count.
    /// </summary>
    [JsonPropertyName("last_record_id")]
    public string? LastRecordId { get; init; } = "0";

    [JsonPropertyName("monitor_id")]
    public string? MonitorId { get; init; } = "";

    [JsonPropertyName("record_count")]
    [Minimum(0)]
    public long? RecordCount { get; init; } = 0L;

    [JsonPropertyName("requests_failed")]
    [Minimum(0)]
    public long? RequestsFailed { get; init; } = 0L;

    [JsonPropertyName("requests_ok")]
    [Minimum(0)]
    public long? RequestsOk { get; init; } = 0L;

    [JsonPropertyName("requests_total")]
    [Minimum(0)]
    public long? RequestsTotal { get; init; } = 0L;

    [JsonPropertyName("run_id")]
    public string? RunId { get; init; } = "0";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("started_at")]
    public string? StartedAt { get; init; }

    [JsonPropertyName("status")]
    public RunStatus Status { get; init; } = RunStatus.Completed;

    /// <summary>
    /// Prose for a human, empty when completed.
    /// </summary>
    [JsonPropertyName("status_reason")]
    public string? StatusReason { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

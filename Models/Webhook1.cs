using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// JSON <c>null</c> clears the webhook; an absent field keeps it. Set
/// <c>webhook.status</c> to turn delivery on or off.
/// </summary>
public record Webhook1
{
    /// <summary>
    /// Exactly two strings are legal: "run.completed" and "run.failed". An empty
    /// list is rejected.
    /// <para>
    /// "run.completed" means the run finished. Read the run's <c>record_count</c> to
    /// see whether it produced records and its <c>status</c> to see whether every
    /// request succeeded. "run.failed" means no request succeeded. Neither fires
    /// for a skipped run.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("events")]
    public IReadOnlyList<string>? Events { get; init; }

    /// <summary>
    /// Always reported on a monitor. Send ACTIVE to turn delivery back on once a
    /// failing endpoint is repaired, or DISABLED to stop it yourself.
    /// <para>
    /// A disabled webhook stops the POST only. The monitor still runs and its
    /// records are still readable through the records cursor, so nothing is lost
    /// while it is off.
    /// </para>
    /// <para>
    /// On the way in it is the one field of this message that may be omitted: an
    /// absent status keeps whatever the monitor already has, so re-sending a
    /// webhook body does not by itself restart delivery to a dead endpoint.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record CreateMonitorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monitor")]
    public MonitorModel? Monitor { get; init; }

    /// <summary>
    /// Returned once, at create, and never again. Issued whether or not the
    /// create supplied a webhook, so keep it.
    /// </summary>
    [JsonPropertyName("webhook_secret")]
    public string? WebhookSecret { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

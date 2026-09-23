using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// The response body returned for any error.
/// </summary>
public record ErrorEnvelopeError
{
    /// <summary>
    /// The error context.
    /// </summary>
    [JsonPropertyName("error")]
    public required EnvelopeError1 Error { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

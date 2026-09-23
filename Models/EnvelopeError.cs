using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// The error context. <c>code</c> is a stable descriptor in all-caps from a closed
/// set per endpoint. <c>message</c> is a human-readable summary of what went wrong.
/// </summary>
public record EnvelopeError
{
    /// <summary>
    /// The error code.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    /// <summary>
    /// The error message.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

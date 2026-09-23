using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// Buffered JSON response body for <c>POST /v1/answer</c>.
/// </summary>
public record AnswerHttpResponse
{
    /// <summary>
    /// Markdown answer text. Inline citations follow the form
    /// <c>text (<see href="url">Source Name</see>)</c>.
    /// </summary>
    [JsonPropertyName("answer")]
    public required string Answer { get; init; }

    /// <summary>
    /// The sources the answer was grounded in. Every source the answer was
    /// given is returned, whether or not the text cites it.
    /// </summary>
    [JsonPropertyName("citations")]
    public required IReadOnlyList<HttpCitation> Citations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

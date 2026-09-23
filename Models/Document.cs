using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// A single search result.
/// <para>
/// <c>url</c> and <c>published_date</c> are returned without being asked for, and either
/// may still be absent for a document that carries no such value. The remaining
/// members are populated only when <c>SearchRequest.fields</c> asked for them.
/// </para>
/// </summary>
public record Document
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// Publication date as ISO 8601 string (e.g. "2024-03-15T00:00:00Z")
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("published_date")]
    public string? PublishedDate { get; init; }

    /// <summary>
    /// The document's highest-scoring snippets, in the order they appear in the document.
    /// <para>
    /// Populated when <c>fields.snippets</c> is selected and passages are available;
    /// empty otherwise.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("snippets")]
    public IReadOnlyList<Snippet>? Snippets { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

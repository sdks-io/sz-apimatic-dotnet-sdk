using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

/// <summary>
/// Tuning for snippet selection.
/// <para>
/// Each option is an upper bound; the response carries at most what is specified here.
/// </para>
/// <para>
/// The service may hold callers to a tighter bound than the ranges below. A larger
/// request is then served at that bound rather than refused, which still carries at
/// most what was specified. Only a value outside the range below is rejected.
/// </para>
/// </summary>
public record SnippetOptions
{
    /// <summary>
    /// Maximum snippets returned across all documents. Accepted range 1-512.
    /// <para>
    /// No default. Left unset, no response-wide ceiling applies at all, which is the
    /// recommended setting: <c>max_snippets_per_result</c> already bounds every document, so the
    /// response is bounded without one.
    /// </para>
    /// <para>
    /// This budget is spent one snippet per document at a time, so every document gets its best
    /// snippet before any document gets a second. This value is potentially raised to ensure each
    /// document can be given at least one snippet.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_snippets")]
    [Minimum(1)]
    [Maximum(512)]
    public int? MaxSnippets { get; init; }

    /// <summary>
    /// Maximum snippets from any single document.
    /// Defaults to 16, accepted range 1-256.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_snippets_per_result")]
    [Minimum(1)]
    [Maximum(256)]
    public int? MaxSnippetsPerResult { get; init; }

    /// <summary>
    /// Ceiling on tokens across all snippets in the response.
    /// Defaults to 8192, accepted range 512-65536.
    /// <para>
    /// Spent in the same order as <c>max_snippets</c>, one snippet per document at a time, but unlike
    /// <c>max_snippets</c> this ceiling is not raised to fit <c>max_results</c>. Set it low against many
    /// results and the budget runs out partway through a round: the documents it does not reach
    /// are still returned, with no snippets at all. If every result needs a snippet, raise this
    /// or lower <c>max_results</c>.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_tokens")]
    [Minimum(512)]
    [Maximum(65536)]
    public int? MaxTokens { get; init; }

    /// <summary>
    /// Ceiling on tokens of snippets from any single document.
    /// Defaults to 4096, accepted range 128-32768.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_tokens_per_result")]
    [Minimum(128)]
    [Maximum(32768)]
    public int? MaxTokensPerResult { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

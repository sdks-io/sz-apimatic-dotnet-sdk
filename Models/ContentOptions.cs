using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

/// <summary>
/// The ceiling on the content returned.
/// <para>
/// The ceiling is an upper bound; the response carries at most what is specified here.
/// </para>
/// <para>
/// The service may hold callers to a tighter bound than the range below. A larger
/// request is then served at that bound rather than refused, which still carries at
/// most what was specified. Only a value outside the range below is rejected.
/// </para>
/// </summary>
public record ContentOptions
{
    /// <summary>
    /// Ceiling on the characters of any single result's content.
    /// <para>
    /// Counts Unicode code points -- Rust <c>char</c>, Python <c>len(s)</c>, JavaScript <c>\[...s\].length</c>.
    /// </para>
    /// <para>
    /// Defaults to 20000, accepted range 100-1000000.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_characters_per_result")]
    [Minimum(100)]
    [Maximum(1000000)]
    public int? MaxCharactersPerResult { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

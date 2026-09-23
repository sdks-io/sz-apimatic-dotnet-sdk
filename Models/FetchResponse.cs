using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// One result per requested URL.
/// </summary>
public record FetchResponse
{
    /// <summary>
    /// One entry per entry in <c>FetchRequest.urls</c>, successful or not, in the order
    /// the URLs were requested.
    /// <para>
    /// Correlate on <c>FetchResult.requested_url</c> rather than on position.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("results")]
    public IReadOnlyList<FetchResult>? Results { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

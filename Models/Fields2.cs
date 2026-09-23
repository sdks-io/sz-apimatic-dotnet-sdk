using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.AnyOf;

namespace SeltzApi.Models;

/// <summary>
/// Which selectable members of <c>Document</c> to populate.
/// <para>
/// If absent, defaults to <c>{content: true}</c>, which returns content under the
/// default ceiling stated on <c>ContentOptions</c>.
/// </para>
/// </summary>
public record Fields2
{
    /// <summary>
    /// Emit <c>Document.content</c>. Unset is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")]
    public Content? Content { get; init; }

    /// <summary>
    /// Emit <c>Document.snippets</c>. Unset is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("snippets")]
    public Snippets? Snippets { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

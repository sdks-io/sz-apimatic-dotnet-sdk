using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Models.AnyOf;

namespace SeltzApi.Models;

/// <summary>
/// The selectable members of a response <c>Document</c>, and how much of each to return.
/// <para>
/// <c>Document.url</c> and <c>Document.published_date</c> are always selected.
/// </para>
/// <para>
/// Each member takes <c>true</c>, <c>false</c>, or an object of ceilings. An object selects the member and
/// bounds it, so <c>{"content": {"max_characters_per_result": 500}}</c> returns content and no
/// snippets. <c>{"content": true}</c> selects content under the default ceiling, which is what
/// <c>{"content": {}}</c> returns as well. <c>false</c> switches the member off.
/// </para>
/// <para>
/// A <c>fields</c> that names neither member returns the defaults below, so <c>{}</c> and a wholly absent
/// <c>fields</c> mean the same thing. A <c>fields</c> that names either is read literally, so
/// <c>{"snippets": true}</c> returns passages and no content.
/// </para>
/// </summary>
public record Fields
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

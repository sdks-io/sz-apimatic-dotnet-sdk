using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Whether this result carries content.
/// <para>
/// Branch on this field, never on whether a given content field is present: a
/// format the page could not produce is unset on an otherwise successful
/// result, so "markdown is absent" does not mean "the fetch failed".
/// </para>
/// <para>
/// A failed fetch is still HTTP 200, with the error status on the result.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FetchStatus2>))]
public sealed record FetchStatus2 : StringEnum<FetchStatus2>
{
    private FetchStatus2(string value) : base(value)
    {
    }

    public static readonly FetchStatus2 Ok = new("ok");

    public static readonly FetchStatus2 Error = new("error");

    public static FetchStatus2 FromValue(string value) => FromValueCore(value);
}

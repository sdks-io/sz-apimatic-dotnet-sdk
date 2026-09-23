using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Whether a <c>FetchResult</c> carries content.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FetchStatus>))]
public sealed record FetchStatus : StringEnum<FetchStatus>
{
    private FetchStatus(string value) : base(value)
    {
    }

    public static readonly FetchStatus Ok = new("ok");

    public static readonly FetchStatus Error = new("error");

    public static FetchStatus FromValue(string value) => FromValueCore(value);
}

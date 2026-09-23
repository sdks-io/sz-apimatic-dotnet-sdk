using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// What a record carries.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RecordType>))]
public sealed record RecordType : StringEnum<RecordType>
{
    private RecordType(string value) : base(value)
    {
    }

    public static readonly RecordType SearchResult = new("search_result");

    public static RecordType FromValue(string value) => FromValueCore(value);
}

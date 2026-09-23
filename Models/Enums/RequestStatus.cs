using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Whether one search request succeeded in a run.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RequestStatus>))]
public sealed record RequestStatus : StringEnum<RequestStatus>
{
    private RequestStatus(string value) : base(value)
    {
    }

    public static readonly RequestStatus Ok = new("ok");

    public static readonly RequestStatus Failed = new("failed");

    public static RequestStatus FromValue(string value) => FromValueCore(value);
}

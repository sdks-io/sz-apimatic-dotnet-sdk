using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Set to <c>paused</c> to create the monitor without starting it. Only <c>active</c>
/// and <c>paused</c> are accepted. Defaults to <c>active</c>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MonitorStatus2>))]
public sealed record MonitorStatus2 : StringEnum<MonitorStatus2>
{
    private MonitorStatus2(string value) : base(value)
    {
    }

    public static readonly MonitorStatus2 Active = new("active");

    public static readonly MonitorStatus2 Paused = new("paused");

    public static readonly MonitorStatus2 Disabled = new("disabled");

    public static readonly MonitorStatus2 Deleted = new("deleted");

    public static MonitorStatus2 FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// A monitor's lifecycle state.
/// <para>
/// <c>active</c> is scheduled and running. <c>paused</c> runs nothing and keeps its
/// records and its record of what it has already delivered. Only those two can
/// be set through the API; <c>disabled</c> and <c>deleted</c> are set by Seltz.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MonitorStatus>))]
public sealed record MonitorStatus : StringEnum<MonitorStatus>
{
    private MonitorStatus(string value) : base(value)
    {
    }

    public static readonly MonitorStatus Active = new("active");

    public static readonly MonitorStatus Paused = new("paused");

    public static readonly MonitorStatus Disabled = new("disabled");

    public static readonly MonitorStatus Deleted = new("deleted");

    public static MonitorStatus FromValue(string value) => FromValueCore(value);
}

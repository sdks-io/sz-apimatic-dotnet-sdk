using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Whether a monitor has a run open on it right now.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RunState>))]
public sealed record RunState : StringEnum<RunState>
{
    private RunState(string value) : base(value)
    {
    }

    public static readonly RunState Idle = new("idle");

    public static readonly RunState Running = new("running");

    public static readonly RunState Unknown = new("unknown");

    public static RunState FromValue(string value) => FromValueCore(value);
}

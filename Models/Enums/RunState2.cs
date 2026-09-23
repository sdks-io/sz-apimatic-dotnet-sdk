using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Live run state. Returned by this RPC only — the list endpoints do not
/// include it.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RunState2>))]
public sealed record RunState2 : StringEnum<RunState2>
{
    private RunState2(string value) : base(value)
    {
    }

    public static readonly RunState2 Idle = new("idle");

    public static readonly RunState2 Running = new("running");

    public static readonly RunState2 Unknown = new("unknown");

    public static RunState2 FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Where the run is in its lifecycle.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AgentRunStatus2>))]
public sealed record AgentRunStatus2 : StringEnum<AgentRunStatus2>
{
    private AgentRunStatus2(string value) : base(value)
    {
    }

    public static readonly AgentRunStatus2 Pending = new("pending");

    public static readonly AgentRunStatus2 Running = new("running");

    public static readonly AgentRunStatus2 Completed = new("completed");

    public static readonly AgentRunStatus2 Failed = new("failed");

    public static readonly AgentRunStatus2 Cancelled = new("cancelled");

    public static AgentRunStatus2 FromValue(string value) => FromValueCore(value);
}

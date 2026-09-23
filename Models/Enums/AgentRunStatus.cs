using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Where a run is in its lifecycle:
/// pending → running → completed / failed / cancelled.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AgentRunStatus>))]
public sealed record AgentRunStatus : StringEnum<AgentRunStatus>
{
    private AgentRunStatus(string value) : base(value)
    {
    }

    public static readonly AgentRunStatus Pending = new("pending");

    public static readonly AgentRunStatus Running = new("running");

    public static readonly AgentRunStatus Completed = new("completed");

    public static readonly AgentRunStatus Failed = new("failed");

    public static readonly AgentRunStatus Cancelled = new("cancelled");

    public static AgentRunStatus FromValue(string value) => FromValueCore(value);
}

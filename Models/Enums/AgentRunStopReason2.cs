using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Why the run stopped. Set once the run reaches a terminal state.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AgentRunStopReason2>))]
public sealed record AgentRunStopReason2 : StringEnum<AgentRunStopReason2>
{
    private AgentRunStopReason2(string value) : base(value)
    {
    }

    public static readonly AgentRunStopReason2 Finished = new("finished");

    public static readonly AgentRunStopReason2 BudgetReached = new("budget_reached");

    public static readonly AgentRunStopReason2 Timeout = new("timeout");

    public static readonly AgentRunStopReason2 Cancelled = new("cancelled");

    public static readonly AgentRunStopReason2 InvalidOutput = new("invalid_output");

    public static readonly AgentRunStopReason2 InternalError = new("internal_error");

    public static AgentRunStopReason2 FromValue(string value) => FromValueCore(value);
}

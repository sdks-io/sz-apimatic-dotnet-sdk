using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// Why a run stopped. <c>budget_reached</c> pairs with <c>completed</c> when the output
/// so far is usable and with <c>failed</c> when it is not.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AgentRunStopReason>))]
public sealed record AgentRunStopReason : StringEnum<AgentRunStopReason>
{
    private AgentRunStopReason(string value) : base(value)
    {
    }

    public static readonly AgentRunStopReason Finished = new("finished");

    public static readonly AgentRunStopReason BudgetReached = new("budget_reached");

    public static readonly AgentRunStopReason Timeout = new("timeout");

    public static readonly AgentRunStopReason Cancelled = new("cancelled");

    public static readonly AgentRunStopReason InvalidOutput = new("invalid_output");

    public static readonly AgentRunStopReason InternalError = new("internal_error");

    public static AgentRunStopReason FromValue(string value) => FromValueCore(value);
}

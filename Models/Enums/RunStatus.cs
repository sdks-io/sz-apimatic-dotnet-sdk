using System.Text.Json.Serialization;
using SeltzApi.Core.Enum;

namespace SeltzApi.Models.Enums;

/// <summary>
/// A run's outcome.
/// <para>
/// <c>completed</c> -- every request succeeded. <c>partial</c> -- at least one request
/// failed after retries and at least one succeeded. <c>failed</c> -- no request
/// succeeded, and no records. <c>skipped</c> -- not attempted and not billed; see
/// <c>status_reason</c>. Any of them may produce no records.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RunStatus>))]
public sealed record RunStatus : StringEnum<RunStatus>
{
    private RunStatus(string value) : base(value)
    {
    }

    public static readonly RunStatus Completed = new("completed");

    public static readonly RunStatus Partial = new("partial");

    public static readonly RunStatus Failed = new("failed");

    public static readonly RunStatus Skipped = new("skipped");

    public static RunStatus FromValue(string value) => FromValueCore(value);
}

using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

public record SearchRequest
{
    /// <summary>
    /// API key. On the HTTP surface, either this or the <c>x-api-key</c> header must
    /// be supplied; the header takes precedence.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    /// <summary>
    /// Exclude results from these domains
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("exclude_domains")]
    public IReadOnlyList<string>? ExcludeDomains { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fields")]
    public Fields2? Fields { get; init; }

    /// <summary>
    /// Only include results published on or after this point. UTC throughout.
    /// <para>
    /// A date "2025-10-28", a datetime "2025-10-28T23:00:00" or
    /// "2025-10-28T23:00:00Z", or an offset from "now", which is the time the
    /// request is served: "now" itself, or "now-" and one duration such as
    /// "now-7d" for the past week. A datetime written without a zone is read as
    /// UTC, and a date written without a time is the start of that day.
    /// </para>
    /// <para>
    /// Offset units are s = second, m = minute, h = hour, d = 24 h, w = 7 d,
    /// M = one calendar month and y = one calendar year. A unit and a count are
    /// both required, and the case carries meaning.
    /// </para>
    /// <para>
    /// A month and a year step the calendar rather than a fixed number of
    /// seconds, and the day of the month is clamped to the length of the target
    /// month. So "now-1M" from the 31st of March lands on the 28th or 29th of
    /// February.
    /// </para>
    /// <para>
    /// An offset is a filter, not a freshness guarantee: the corpus refreshes on
    /// its own cadence, so a window of an hour or two can return nothing.
    /// </para>
    /// <para>
    /// Only a single offset before "now" is accepted. Rounding, several terms in
    /// one value, a "+" offset, and any anchor other than "now" are rejected.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("from_date")]
    public string? FromDate { get; init; }

    /// <summary>
    /// Include only results from these domains (e.g., \["google.com", "example.com"\])
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("include_domains")]
    public IReadOnlyList<string>? IncludeDomains { get; init; }

    /// <summary>
    /// Maximum number of results to return. Defaults to 10. A larger value is
    /// served as 1000.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("max_results")]
    [Minimum(0)]
    public int? MaxResults { get; init; }

    /// <summary>
    /// The search query.
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; init; } = "";

    /// <summary>
    /// Restricts the results to one vertical or data set.
    /// <para>
    /// Currently available: "news", "wikipedia", "people", "companies".
    /// </para>
    /// <para>
    /// When omitted, the default scope is searched. A scope that does not exist,
    /// or that this key cannot reach, returns 404.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    /// <summary>
    /// How much work goes into ordering the results. It does not change which
    /// corpus is searched -- that is <c>scope</c> -- so any scope can be requested in
    /// either tier.
    /// <para>
    /// <c>"base"</c> returns first-stage ranking. <c>"pro"</c> adds a ranking stage for
    /// higher precision at the top of the list.
    /// </para>
    /// <para>
    /// Unset resolves to <c>"pro"</c>, so <c>"base"</c> is opt-out. A scope with no Pro
    /// configuration serves <c>"pro"</c> exactly as <c>"base"</c> rather than failing, so a
    /// caller may always ask for <c>"pro"</c>.
    /// </para>
    /// <para>
    /// The name is matched without regard to case, and surrounding whitespace is
    /// ignored, so "pro", "PRO" and " Pro " are one tier. A name that is neither
    /// is rejected rather than defaulted, because the value selects a price.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tier")]
    public string? Tier { get; init; }

    /// <summary>
    /// Only include results published on or before this point. UTC throughout.
    /// <para>
    /// A date, a datetime, or an offset from "now", in the same spellings
    /// from_date takes. A date written without a time covers the whole of that
    /// day, ending at 23:59:59.999; an offset is an instant.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("to_date")]
    public string? ToDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

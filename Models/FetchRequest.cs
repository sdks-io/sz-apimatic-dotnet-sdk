using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;

namespace SeltzApi.Models;

public record FetchRequest
{
    /// <summary>
    /// API key to access the service. Either this or the <c>x-api-key</c> header must
    /// be supplied on the HTTP surface; the header takes precedence and is the
    /// documented path. On gRPC this field is the only carrier.
    /// <para>
    /// Each URL that comes back with the OK status is billed. A URL that comes
    /// back with an error is not. The call is refused up front unless the balance
    /// covers the whole batch.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    /// <summary>
    /// Representations to return, as documented format names.
    /// <para>
    /// Omitted, or sent empty, means <c>\["markdown"\]</c> -- a repeated field carries
    /// no presence, so the two are the same request and neither means "no
    /// formats".
    /// </para>
    /// <para>
    /// Documented names:
    /// </para>
    /// <para>
    /// "markdown" -- the main content as Markdown, boilerplate removed.
    /// </para>
    /// <para>
    /// An unrecognized name is rejected.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("formats")]
    public IReadOnlyList<string>? Formats { get; init; }

    /// <summary>
    /// The service tier, which selects the price. Send <c>"pro"</c>. Unset resolves to
    /// <c>"pro"</c>.
    /// <para>
    /// An unrecognized value is rejected rather than defaulted, because the value
    /// selects a price. The name is matched exactly.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tier")]
    public string? Tier { get; init; }

    /// <summary>
    /// Wall-clock budget for one URL, in milliseconds.
    /// <para>
    /// Applies to each URL, not to the batch. A URL that exceeds the budget gets
    /// <c>error.code = "timeout"</c>; the others in the same request are unaffected.
    /// </para>
    /// <para>
    /// Unset means 75000, which is also the maximum; a larger value is served as
    /// 75000, and a value below 1000 is served as 1000.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("timeout_ms")]
    [Minimum(0)]
    public int? TimeoutMs { get; init; }

    /// <summary>
    /// The URLs to fetch. At least one, at most 20.
    /// <para>
    /// An empty list, more than 20 entries, a duplicate entry, a blank or padded
    /// entry, or an entry over 2048 bytes is rejected before any billing --
    /// duplicates because <c>FetchResult.requested_url</c> is the correlation key and
    /// a repeated key is ambiguous.
    /// </para>
    /// <para>
    /// Everything else is reported inside a <c>200</c> as that URL's error result: a
    /// value that is not an absolute <c>http</c> or <c>https</c> URL, a host that does not
    /// resolve or that this service will not fetch, an origin that refuses, and a
    /// document that is not an HTML page.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("urls")]
    public IReadOnlyList<string>? Urls { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

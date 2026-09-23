using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// Why one URL failed.
/// </summary>
public record FetchError
{
    /// <summary>
    /// A stable, machine-readable reason. A client must treat an unrecognized
    /// code as a generic failure rather than rejecting the result.
    /// <para>
    /// Documented codes:
    /// </para>
    /// <para>
    /// "invalid_url"              -- not a parseable absolute URL.
    /// "unsupported_scheme"       -- parseable, but not <c>http</c> or <c>https</c>.
    /// "url_not_accessible"       -- DNS, connection, TLS, or navigation
    /// failure reaching the origin, or a host
    /// this service does not fetch.
    /// "timeout"                  -- the fetch did not finish within
    /// <c>timeout_ms</c>.
    /// "unsupported_content_type" -- the document is not an HTML page. PDFs,
    /// images, archives, and other binaries are
    /// out of scope. Refused from the URL before
    /// the fetch, or from the media type the
    /// origin declared after it.
    /// "extraction_failed"        -- the page was fetched, but no requested
    /// format could be produced from it.
    /// "upstream_error"           -- the fetch path itself failed. Ours, not
    /// the URL's.
    /// </para>
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; } = "";

    /// <summary>
    /// A human-readable explanation. Always set when this message is present:
    /// <c>FetchError</c> itself is optional on the result, so an absent error is
    /// absent whole, and there is no state where a failure arrives without a
    /// reason. For operators and logs. Never parse it -- branch on <c>code</c>. The
    /// wording of any given message may change at any time.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; } = "";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

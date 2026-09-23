using System.Text.Json.Serialization;
using SeltzApi.Core.Models;
using SeltzApi.Core.Validation.Attributes;
using SeltzApi.Models.Enums;

namespace SeltzApi.Models;

/// <summary>
/// The outcome for one URL.
/// </summary>
public record FetchResult
{
    /// <summary>
    /// The origin's declared media type for the main document, without
    /// parameters.
    /// <para>
    /// Frequently unset, including on results that carry content. Never branch on
    /// it: <c>status</c> says whether a result carries content.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public FetchError1? Error { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fetched_at")]
    public string? FetchedAt { get; init; }

    /// <summary>
    /// The URL the content actually came from, after HTTP redirects and any
    /// client-side navigation. Equal to <c>requested_url</c> when nothing redirected.
    /// <para>
    /// Set on a result whose <c>status</c> is ERROR only when the failure happened
    /// after the origin answered, such as a page this service could not extract.
    /// Unset when the URL was never reached.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("final_url")]
    public string? FinalUrl { get; init; }

    /// <summary>
    /// The origin's HTTP status code for the main document. Unset when no network
    /// response was observed for the navigation.
    /// <para>
    /// An HTTP error status is not a fetch failure: this service renders the
    /// origin's error page, so a 404 arrives as an OK result carrying 404. On a
    /// result whose <c>status</c> is ERROR, this follows <c>final_url</c> - set only when
    /// the failure happened after the origin answered.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("http_status_code")]
    [Minimum(0)]
    public int? HttpStatusCode { get; init; }

    /// <summary>
    /// The page's main content as Markdown, with boilerplate removed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("markdown")]
    public string? Markdown { get; init; }

    /// <summary>
    /// The URL this answers, echoed verbatim from the request -- byte for byte,
    /// never normalized, and never the post-redirect URL. This is the correlation
    /// key. Where redirects landed is <c>final_url</c>.
    /// </summary>
    [JsonPropertyName("requested_url")]
    public string? RequestedUrl { get; init; } = "";

    [JsonPropertyName("status")]
    public FetchStatus2 Status { get; init; } = FetchStatus2.Ok;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

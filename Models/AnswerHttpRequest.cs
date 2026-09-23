using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

/// <summary>
/// JSON request body for <c>POST /v1/answer</c>.
/// </summary>
public record AnswerHttpRequest
{
    /// <summary>
    /// API key. Either this or the <c>x-api-key</c> header must be supplied;
    /// the header takes precedence.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    /// <summary>
    /// When true, citations carry the document content text. Default false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("include_content")]
    public bool? IncludeContent { get; init; }

    /// <summary>
    /// Selects the answer tier, which determines behavior and billing.
    /// Omitted resolves to the default tier. Independent of <c>scope</c>; the
    /// response shape is unchanged.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("model")]
    public string? Model { get; init; }

    /// <summary>
    /// The natural-language question.
    /// </summary>
    [JsonPropertyName("query")]
    public required string Query { get; init; }

    /// <summary>
    /// Optional <c>OpenAI</c> <c>response_format</c> object (`{"type": "text" |
    /// "json_object" | "json_schema", ...}`), accepted as raw JSON exactly
    /// like <c>/v1/chat/completions</c>. Under a structured type no inline
    /// citations are added, so the answer stays schema-valid; a malformed
    /// value is a <c>400</c> before billing. Omitted leaves the answer as Markdown
    /// prose.
    /// Applies at every tier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("response_format")]
    public object? ResponseFormat { get; init; }

    /// <summary>
    /// Restricts the grounding search to one scope.
    /// <para>
    /// Currently available:
    /// </para>
    /// <list type="bullet">
    ///   <item><description><c>news</c></description></item>
    ///   <item><description><c>wikipedia</c></description></item>
    ///   <item><description><c>people</c></description></item>
    ///   <item><description><c>companies</c></description></item>
    /// </list>
    /// <para>
    /// Omitted, empty or whitespace-only searches the default scope.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    /// <summary>
    /// When true, stream the answer as OpenAI-mimic SSE chunks. Default false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stream")]
    public bool? Stream { get; init; }

    /// <summary>
    /// Steers how the answer is presented — tone, voice, format. It is
    /// subordinate to the grounding and citation rules, which stay in force.
    /// That precedence is instructional, not a sandbox. Omitted, empty or
    /// whitespace-only leaves the presentation unchanged. Applies at every
    /// tier and composes with <c>response_format</c>. At most 8 KiB of UTF-8; a
    /// longer value is a <c>400</c> before billing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("system_prompt")]
    public string? SystemPrompt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

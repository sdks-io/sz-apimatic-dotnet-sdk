using System.Text.Json.Serialization;

namespace SeltzApi.Models;

public record CreateAgentRunRequest
{
    /// <summary>
    /// The API key, on gRPC requests. REST reads the <c>x-api-key</c> header instead.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    /// <summary>
    /// Effort level: how much research the run may do, and its price. One of
    /// the configured level names (e.g. <c>low</c>, <c>medium</c>, <c>high</c>, <c>max</c>).
    /// Omitted = the default level.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("effort")]
    public string? Effort { get; init; }

    /// <summary>
    /// Optional OpenAI-style <c>response_format</c> object requesting structured
    /// output: <c>{"type": "text" | "json_object" | "json_schema", ...}</c>, with
    /// <c>name</c> / <c>schema</c> / <c>strict</c> for type <c>json_schema</c>. A structured type
    /// adds <c>output.structured</c> and its <c>grounding</c> alongside the cited text;
    /// type <c>text</c> is accepted and requests no structure. On gRPC the object is
    /// JSON-encoded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("output_schema")]
    public object? OutputSchema { get; init; }

    /// <summary>
    /// The natural-language question. Instructions inside the query are
    /// followed.
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; init; } = "";
}

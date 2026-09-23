using System.Text.Json.Serialization;
using SeltzApi.Core.Models;

namespace SeltzApi.Models;

public record GetRunResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("run")]
    public Run? Run { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}

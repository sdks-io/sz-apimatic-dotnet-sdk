using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SeltzApi.Core.Extensions;
using SeltzApi.Core.Models;

namespace SeltzApi.Models.AnyOf;

/// <summary>
/// Emit <c>Document.content</c>. Unset is true.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record Content
{
    private readonly Optional<bool> _boolValue;

    private readonly Optional<ContentOptions> _contentOptionsValue;

    private Content(Optional<bool> boolValue, Optional<ContentOptions> contentOptionsValue)
    {
        _boolValue = boolValue;
        _contentOptionsValue = contentOptionsValue;
    }

    public static Content Bool(bool value) => new(Optional<bool>.Some(value), default);

    public static Content ContentOptions(ContentOptions value) =>
        new(default, Optional<ContentOptions>.Some(value));

    public bool TryGetBool(out bool value) => _boolValue.TryGetValue(out value);

    public bool TryGetContentOptions(out ContentOptions value) => _contentOptionsValue.TryGetValue(out value);

    public static implicit operator Content(bool value) => Bool(value);

    public static implicit operator Content(ContentOptions value) => ContentOptions(value);
}

file sealed class ContentConverter : JsonConverter<Content>
{
    public override Content Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<bool>(root, options, out var boolValue))
        {
            return Content.Bool(boolValue);
        }
        if (JsonSerializer.TryDeserialize<ContentOptions>(root, options, out var contentOptionsValue))
        {
            return Content.ContentOptions(contentOptionsValue);
        }
        throw new JsonException($"JSON does not match bool or ContentOptions schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        if (value.TryGetBool(out var boolValue))
        {
            JsonSerializer.Serialize(writer, boolValue, options);
        }
        else if (value.TryGetContentOptions(out var contentOptionsValue))
        {
            JsonSerializer.Serialize(writer, contentOptionsValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Content)} contains no valid value to serialize.");
        }
    }
}

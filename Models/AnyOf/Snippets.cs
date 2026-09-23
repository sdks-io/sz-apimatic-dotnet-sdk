using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SeltzApi.Core.Extensions;
using SeltzApi.Core.Models;

namespace SeltzApi.Models.AnyOf;

/// <summary>
/// Emit <c>Document.snippets</c>. Unset is false.
/// </summary>
[JsonConverter(typeof(SnippetsConverter))]
public record Snippets
{
    private readonly Optional<bool> _boolValue;

    private readonly Optional<SnippetOptions> _snippetOptionsValue;

    private Snippets(Optional<bool> boolValue, Optional<SnippetOptions> snippetOptionsValue)
    {
        _boolValue = boolValue;
        _snippetOptionsValue = snippetOptionsValue;
    }

    public static Snippets Bool(bool value) => new(Optional<bool>.Some(value), default);

    public static Snippets SnippetOptions(SnippetOptions value) =>
        new(default, Optional<SnippetOptions>.Some(value));

    public bool TryGetBool(out bool value) => _boolValue.TryGetValue(out value);

    public bool TryGetSnippetOptions(out SnippetOptions value) => _snippetOptionsValue.TryGetValue(out value);

    public static implicit operator Snippets(bool value) => Bool(value);

    public static implicit operator Snippets(SnippetOptions value) => SnippetOptions(value);
}

file sealed class SnippetsConverter : JsonConverter<Snippets>
{
    public override Snippets Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<bool>(root, options, out var boolValue))
        {
            return Snippets.Bool(boolValue);
        }
        if (JsonSerializer.TryDeserialize<SnippetOptions>(root, options, out var snippetOptionsValue))
        {
            return Snippets.SnippetOptions(snippetOptionsValue);
        }
        throw new JsonException($"JSON does not match bool or SnippetOptions schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Snippets value, JsonSerializerOptions options)
    {
        if (value.TryGetBool(out var boolValue))
        {
            JsonSerializer.Serialize(writer, boolValue, options);
        }
        else if (value.TryGetSnippetOptions(out var snippetOptionsValue))
        {
            JsonSerializer.Serialize(writer, snippetOptionsValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Snippets)} contains no valid value to serialize.");
        }
    }
}

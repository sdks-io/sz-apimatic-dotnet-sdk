
# Document

A single search result.

`url` and `published_date` are returned without being asked for, and either
may still be absent for a document that carries no such value. The remaining
members are populated only when `SearchRequest.fields` asked for them.

*This model accepts additional fields of type object.*

## Structure

`Document`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Content` | `string` | Optional | - |
| `PublishedDate` | `string` | Optional | Publication date as ISO 8601 string (e.g. "2024-03-15T00:00:00Z") |
| `Snippets` | [`List<Snippet>`](../../doc/models/snippet.md) | Optional | The document's highest-scoring snippets, in the order they appear in the document.<br><br>Populated when `fields.snippets` is selected and passages are available;<br>empty otherwise. |
| `Url` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

Document document = new Document
{
    Content = "content0",
    PublishedDate = "published_date0",
    Snippets = new List<Snippet>
    {
        null,
        new Snippet
        {
        },
    },
    Url = "url0",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


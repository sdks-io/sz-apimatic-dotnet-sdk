
# Fields

The selectable members of a response `Document`, and how much of each to return.

`Document.url` and `Document.published_date` are always selected.

Each member takes `true`, `false`, or an object of ceilings. An object selects the member and
bounds it, so `{"content": {"max_characters_per_result": 500}}` returns content and no
snippets. `{"content": true}` selects content under the default ceiling, which is what
`{"content": {}}` returns as well. `false` switches the member off.

A `fields` that names neither member returns the defaults below, so `{}` and a wholly absent
`fields` mean the same thing. A `fields` that names either is read literally, so
`{"snippets": true}` returns passages and no content.

*This model accepts additional fields of type object.*

## Structure

`Fields`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Content` | [`FieldsContent`](../../doc/models/containers/fields-content.md) | Optional | This is a container for one-of cases. |
| `Snippets` | [`FieldsSnippets`](../../doc/models/containers/fields-snippets.md) | Optional | This is a container for one-of cases. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Models.Containers;
using SeltzApi.Standard.Utilities;

Fields fields = new Fields
{
    Content = FieldsContent.FromBoolean(true),
    Snippets = FieldsSnippets.FromBoolean(true),
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Snippet

One passage selected from a document's body.

*This model accepts additional fields of type object.*

## Structure

`Snippet`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Text` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

Snippet snippet = new Snippet
{
    Text = "text0",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


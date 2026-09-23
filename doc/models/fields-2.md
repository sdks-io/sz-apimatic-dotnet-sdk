
# Fields 2

Which selectable members of `Document` to populate.

If absent, defaults to `{content: true}`, which returns content under the
default ceiling stated on `ContentOptions`.

*This model accepts additional fields of type object.*

## Structure

`Fields2`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Content` | [`Fields2Content`](../../doc/models/containers/fields-2-content.md) | Optional | This is a container for one-of cases. |
| `Snippets` | [`Fields2Snippets`](../../doc/models/containers/fields-2-snippets.md) | Optional | This is a container for one-of cases. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Models.Containers;
using SeltzApi.Standard.Utilities;

Fields2 fields2 = new Fields2
{
    Content = Fields2Content.FromBoolean(true),
    Snippets = Fields2Snippets.FromBoolean(true),
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


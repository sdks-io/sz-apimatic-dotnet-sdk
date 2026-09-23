
# Http Citation

HTTP-shape citation. Mirrors the `Citation` proto.

*This model accepts additional fields of type object.*

## Structure

`HttpCitation`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Content` | `string` | Optional | Document content text (only when `include_content = true`). |
| `Url` | `string` | Required | URL of the source document. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

HttpCitation httpCitation = new HttpCitation
{
    Url = "url6",
    Content = "content6",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


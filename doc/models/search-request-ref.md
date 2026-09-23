
# Search Request Ref

*This model accepts additional fields of type object.*

## Structure

`SearchRequestRef`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Query` | `string` | Optional | The request's query text, carried here so a record can be rendered without<br>a second lookup. |
| `RequestId` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

SearchRequestRef searchRequestRef = new SearchRequestRef
{
    Query = "query0",
    RequestId = "request_id8",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


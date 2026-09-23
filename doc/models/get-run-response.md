
# Get Run Response

*This model accepts additional fields of type object.*

## Structure

`GetRunResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Run` | [`Run`](../../doc/models/run.md) | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

GetRunResponse getRunResponse = new GetRunResponse
{
    Run = null,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Update Monitor Response

*This model accepts additional fields of type object.*

## Structure

`UpdateMonitorResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Monitor` | [`Monitor`](../../doc/models/monitor.md) | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

UpdateMonitorResponse updateMonitorResponse = new UpdateMonitorResponse
{
    Monitor = null,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


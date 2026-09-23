
# Get Monitor Response

*This model accepts additional fields of type object.*

## Structure

`GetMonitorResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Monitor` | [`Monitor`](../../doc/models/monitor.md) | Optional | - |
| `RunState` | [`RunState2`](../../doc/models/run-state-2.md) | Required | **Default**: `RunState2.idle` |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

GetMonitorResponse getMonitorResponse = new GetMonitorResponse
{
    RunState = RunState2.Idle,
    Monitor = null,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Monitor

*This model accepts additional fields of type object.*

## Structure

`Monitor`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Cadence` | `string` | Required | - |
| `CreatedAt` | `string` | Optional | - |
| `MonitorId` | `string` | Optional | - |
| `Name` | `string` | Optional | - |
| `SearchRequests` | [`List<MonitorSearchRequest>`](../../doc/models/monitor-search-request.md) | Optional | - |
| `Status` | [`MonitorStatus`](../../doc/models/monitor-status.md) | Required | **Default**: `MonitorStatus.active` |
| `UpdatedAt` | `string` | Optional | - |
| `Webhook` | [`Webhook`](../../doc/models/webhook.md) | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

Monitor monitor = new Monitor
{
    Cadence = "cadence6",
    Status = MonitorStatus.Active,
    CreatedAt = "created_at2",
    MonitorId = "monitor_id2",
    Name = "name4",
    SearchRequests = new List<MonitorSearchRequest>
    {
        null,
    },
    UpdatedAt = "updated_at0",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


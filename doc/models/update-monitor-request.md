
# Update Monitor Request

*This model accepts additional fields of type object.*

## Structure

`UpdateMonitorRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Cadence` | `string` | Required | - |
| `ApiKey` | `string` | Optional | - |
| `MonitorId` | `string` | Optional | - |
| `Name` | `string` | Optional | - |
| `SearchRequests` | [`List<SearchRequest>`](../../doc/models/search-request.md) | Optional | Replaces the list wholesale when set. An empty list is read as "not set"<br>and keeps the current requests. A request keeps its id and its health when<br>every field of its body is unchanged. |
| `Status` | [`MonitorStatus?`](../../doc/models/monitor-status.md) | Optional | - |
| `Webhook` | [`Webhook1`](../../doc/models/webhook-1.md) | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

UpdateMonitorRequest updateMonitorRequest = new UpdateMonitorRequest
{
    Cadence = "cadence8",
    ApiKey = "api_key2",
    MonitorId = "monitor_id8",
    Name = "name0",
    SearchRequests = new List<SearchRequest>
    {
        null,
    },
    Status = MonitorStatus.Active,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


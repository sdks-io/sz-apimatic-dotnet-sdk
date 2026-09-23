
# Create Monitor Request

*This model accepts additional fields of type object.*

## Structure

`CreateMonitorRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Cadence` | `string` | Required | - |
| `ApiKey` | `string` | Optional | - |
| `Name` | `string` | Optional | Unique per org among live monitors; a deleted monitor's name becomes<br>available again. At most 512 bytes of UTF-8. |
| `SearchRequests` | [`List<SearchRequest>`](../../doc/models/search-request.md) | Optional | At least one, at most 1000. Every request runs on every run. A request<br>with an `api_key` set, a blank `query`, or a body identical to another in<br>the list is rejected. |
| `Status` | [`MonitorStatus2?`](../../doc/models/monitor-status-2.md) | Optional | - |
| `Webhook` | [`Webhook`](../../doc/models/webhook.md) | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

CreateMonitorRequest createMonitorRequest = new CreateMonitorRequest
{
    Cadence = "cadence2",
    ApiKey = "api_key2",
    Name = "name0",
    SearchRequests = new List<SearchRequest>
    {
        null,
    },
    Status = MonitorStatus2.Active,
    Webhook = null,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


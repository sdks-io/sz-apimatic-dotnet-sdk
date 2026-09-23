
# Monitor Search Request

A search request stored on a monitor, with its server-assigned id.

*This model accepts additional fields of type object.*

## Structure

`MonitorSearchRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ConsecutiveFailures` | `long?` | Optional | Consecutive failed runs for this request.<br><br>**Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `LastSuccessAt` | `string` | Optional | - |
| `Request` | [`SearchRequest`](../../doc/models/search-request.md) | Optional | - |
| `RequestId` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

MonitorSearchRequest monitorSearchRequest = new MonitorSearchRequest
{
    ConsecutiveFailures = 0L,
    LastSuccessAt = "last_success_at6",
    Request = null,
    RequestId = "request_id4",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


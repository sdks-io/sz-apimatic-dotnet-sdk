
# Run Request

One run's outcome for one search request.

*This model accepts additional fields of type object.*

## Structure

`RunRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CompletedAt` | `string` | Optional | - |
| `NewRecords` | `long?` | Optional | **Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `Reason` | `string` | Optional | Why the request failed, empty when it succeeded. Not machine-readable. |
| `RequestId` | `string` | Optional | - |
| `ResultsReturned` | `long?` | Optional | **Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `Status` | [`RequestStatus`](../../doc/models/request-status.md) | Required | **Default**: `RequestStatus.ok` |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

RunRequest runRequest = new RunRequest
{
    Status = RequestStatus.Ok,
    CompletedAt = "completed_at0",
    NewRecords = 0L,
    Reason = "reason6",
    RequestId = "request_id0",
    ResultsReturned = 0L,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


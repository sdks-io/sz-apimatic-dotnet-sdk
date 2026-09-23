
# Run

*This model accepts additional fields of type object.*

## Structure

`Run`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CompletedAt` | `string` | Optional | - |
| `FirstRecordId` | `string` | Optional | The lowest `record_id` this run produced. Records are not contiguous; use<br>`record_count` for the count.<br><br>**Default**: `"0"` |
| `LastRecordId` | `string` | Optional | The highest `record_id` this run produced. Records are not contiguous; use<br>`record_count` for the count.<br><br>**Default**: `"0"` |
| `MonitorId` | `string` | Optional | - |
| `RecordCount` | `long?` | Optional | **Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `RequestsFailed` | `long?` | Optional | **Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `RequestsOk` | `long?` | Optional | **Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `RequestsTotal` | `long?` | Optional | **Default**: `0L`<br><br>**Constraints**: `>= 0` |
| `RunId` | `string` | Optional | **Default**: `"0"` |
| `StartedAt` | `string` | Optional | - |
| `Status` | [`RunStatus`](../../doc/models/run-status.md) | Required | **Default**: `RunStatus.completed` |
| `StatusReason` | `string` | Optional | Prose for a human, empty when completed. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

Run run = new Run
{
    Status = RunStatus.Completed,
    CompletedAt = "completed_at0",
    FirstRecordId = "0",
    LastRecordId = "0",
    MonitorId = "monitor_id6",
    RecordCount = 0L,
    RequestsFailed = 0L,
    RequestsOk = 0L,
    RequestsTotal = 0L,
    RunId = "0",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


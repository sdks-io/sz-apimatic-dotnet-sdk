
# Webhook

*This model accepts additional fields of type object.*

## Structure

`Webhook`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Events` | `List<string>` | Optional | Exactly two strings are legal: "run.completed" and "run.failed". An empty<br>list is rejected.<br><br>"run.completed" means the run finished. Read the run's `record_count` to<br>see whether it produced records and its `status` to see whether every<br>request succeeded. "run.failed" means no request succeeded. Neither fires<br>for a skipped run. |
| `Status` | `string` | Optional | Always reported on a monitor. Send ACTIVE to turn delivery back on once a<br>failing endpoint is repaired, or DISABLED to stop it yourself.<br><br>A disabled webhook stops the POST only. The monitor still runs and its<br>records are still readable through the records cursor, so nothing is lost<br>while it is off.<br><br>On the way in it is the one field of this message that may be omitted: an<br>absent status keeps whatever the monitor already has, so re-sending a<br>webhook body does not by itself restart delivery to a dead endpoint. |
| `Url` | `string` | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

Webhook webhook = new Webhook
{
    Events = new List<string>
    {
        "events8",
    },
    Status = "status6",
    Url = "url6",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# List Monitors Response

*This model accepts additional fields of type object.*

## Structure

`ListMonitorsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `HasMore` | `bool?` | Optional | True when limit or the byte budget cut the page short. Page forward with<br>before = monitors\[last\].monitor_id.<br><br>**Default**: `false` |
| `Monitors` | [`List<Monitor>`](../../doc/models/monitor.md) | Optional | Newest first. A short page is normal: a page ends at limit or at a byte<br>budget, whichever binds first. A monitor carries its whole request list,<br>so a count alone cannot bound the response. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

ListMonitorsResponse listMonitorsResponse = new ListMonitorsResponse
{
    HasMore = false,
    Monitors = new List<Monitor>
    {
        null,
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


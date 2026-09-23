
# List Runs Response

*This model accepts additional fields of type object.*

## Structure

`ListRunsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `HasMore` | `bool?` | Optional | True when limit cut the page short.<br><br>**Default**: `false` |
| `Runs` | [`List<Run>`](../../doc/models/run.md) | Optional | Newest first by default, so \[0\] is the latest run. Page back with<br>before = runs\[last\].run_id; pass sort = SORT_ORDER_ASC to walk forward<br>instead, and page with since = runs\[last\].run_id. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

ListRunsResponse listRunsResponse = new ListRunsResponse
{
    HasMore = false,
    Runs = new List<Run>
    {
        null,
        new Run
        {
            Status = RunStatus.Completed,
        },
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


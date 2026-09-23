
# List Records Response

*This model accepts additional fields of type object.*

## Structure

`ListRecordsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `HasMore` | `bool?` | Optional | True when limit or the byte budget cut the page short. Page forward with<br>since = records\[last\].record_id.<br><br>**Default**: `false` |
| `Records` | [`List<Record>`](../../doc/models/record.md) | Optional | Oldest first. A short page is normal: a page ends at limit or at a byte<br>budget, whichever binds first. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

ListRecordsResponse listRecordsResponse = new ListRecordsResponse
{
    HasMore = false,
    Records = new List<Record>
    {
        null,
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Search Record

*This model accepts additional fields of type object.*

## Structure

`SearchRecord`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Document` | [`Document`](../../doc/models/document.md) | Optional | - |
| `MatchedRequests` | [`List<SearchRequestRef>`](../../doc/models/search-request-ref.md) | Optional | Only the requests that matched in the run that emitted this record. A record<br>is emitted once, on first sight, so a request that would match it in a later<br>run never attaches to it. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

SearchRecord searchRecord = new SearchRecord
{
    Document = null,
    MatchedRequests = new List<SearchRequestRef>
    {
        null,
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


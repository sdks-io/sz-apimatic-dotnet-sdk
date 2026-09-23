
# Record

*This model accepts additional fields of type object.*

## Structure

`Record`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SearchResult` | [`SearchRecord`](../../doc/models/search-record.md) | Required | - |
| `FirstSeenAt` | `string` | Optional | - |
| `RecordId` | `string` | Optional | **Default**: `"0"` |
| `RunId` | `string` | Optional | **Default**: `"0"` |
| `Type` | [`RecordType`](../../doc/models/record-type.md) | Required | **Default**: `RecordType.search_result` |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

Record record = new Record
{
    SearchResult = new SearchRecord
    {
        Document = null,
        MatchedRequests = new List<SearchRequestRef>
        {
            null,
        },
        ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
    },
    Type = RecordType.SearchResult,
    FirstSeenAt = "first_seen_at0",
    RecordId = "0",
    RunId = "0",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Payload

*This model accepts additional fields of type object.*

## Structure

`Payload`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SearchResult` | [`SearchRecord`](../../doc/models/search-record.md) | Required | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

Payload payload = new Payload
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
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


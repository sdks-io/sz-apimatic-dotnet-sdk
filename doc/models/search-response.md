
# Search Response

*This model accepts additional fields of type object.*

## Structure

`SearchResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Documents` | [`List<Document>`](../../doc/models/document.md) | Optional | Documents that are most relevant to the query |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

SearchResponse searchResponse = new SearchResponse
{
    Documents = new List<Document>
    {
        null,
        new Document
        {
        },
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Fetch Response

One result per requested URL.

*This model accepts additional fields of type object.*

## Structure

`FetchResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Results` | [`List<FetchResult>`](../../doc/models/fetch-result.md) | Optional | One entry per entry in `FetchRequest.urls`, successful or not, in the order<br>the URLs were requested.<br><br>Correlate on `FetchResult.requested_url` rather than on position. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

FetchResponse fetchResponse = new FetchResponse
{
    Results = new List<FetchResult>
    {
        null,
        new FetchResult
        {
            Status = FetchStatus2.Ok,
        },
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


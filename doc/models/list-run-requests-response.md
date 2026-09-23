
# List Run Requests Response

*This model accepts additional fields of type object.*

## Structure

`ListRunRequestsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Requests` | [`List<RunRequest>`](../../doc/models/run-request.md) | Optional | Ordered by request_id. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

ListRunRequestsResponse listRunRequestsResponse = new ListRunRequestsResponse
{
    Requests = new List<RunRequest>
    {
        null,
        new RunRequest
        {
            Status = RequestStatus.Ok,
        },
        new RunRequest
        {
            Status = RequestStatus.Ok,
        },
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


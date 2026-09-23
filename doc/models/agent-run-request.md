
# Agent Run Request

The request a run was created with.

*This model accepts additional fields of type object.*

## Structure

`AgentRunRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Effort` | `string` | Optional | The effort level the run executes at: the request's `effort`, or the<br>default level when it named none. |
| `OutputSchema` | `object` | Optional | The request's `output_schema`, when one was given. On gRPC the object is<br>JSON-encoded. |
| `Query` | `string` | Optional | The natural-language question. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

AgentRunRequest agentRunRequest = new AgentRunRequest
{
    Effort = "effort8",
    OutputSchema = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
    Query = "query8",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


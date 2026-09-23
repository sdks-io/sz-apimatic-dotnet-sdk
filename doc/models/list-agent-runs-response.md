
# List Agent Runs Response

List-runs response: one page of runs.

*This model accepts additional fields of type object.*

## Structure

`ListAgentRunsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Next` | `string` | Optional | Cursor to the next page. Unset on the last page. |
| `Runs` | [`List<AgentRun>`](../../doc/models/agent-run.md) | Optional | The page's runs, newest first. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

ListAgentRunsResponse listAgentRunsResponse = new ListAgentRunsResponse
{
    Next = "next6",
    Runs = new List<AgentRun>
    {
        null,
        new AgentRun
        {
        },
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


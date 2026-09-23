
# Agent Run

An agent run.

*This model accepts additional fields of type object.*

## Structure

`AgentRun`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CompletedAt` | `string` | Optional | When the run reached a terminal state. Unset until then. |
| `CreatedAt` | `string` | Optional | When the run was created, as an ISO 8601 timestamp. |
| `Id` | `string` | Optional | Unique run id. |
| `MObject` | `string` | Optional | Object type, always "agent.run". |
| `Output` | [`AgentRunOutput2`](../../doc/models/agent-run-output-2.md) | Optional | - |
| `Request` | [`AgentRunRequest2`](../../doc/models/agent-run-request-2.md) | Optional | - |
| `StartedAt` | `string` | Optional | When the run started. Unset while pending. |
| `Status` | [`AgentRunStatus2?`](../../doc/models/agent-run-status-2.md) | Optional | **Default**: `AgentRunStatus2.pending` |
| `StopReason` | [`AgentRunStopReason2?`](../../doc/models/agent-run-stop-reason-2.md) | Optional | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

AgentRun agentRun = new AgentRun
{
    CompletedAt = "completed_at4",
    CreatedAt = "created_at0",
    Id = "id2",
    MObject = "object0",
    Output = null,
    Status = AgentRunStatus2.Pending,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


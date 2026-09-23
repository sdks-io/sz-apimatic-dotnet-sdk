
# Agent Run Stop Reason 2

Why the run stopped. Set once the run reaches a terminal state.

## Enumeration

`AgentRunStopReason2`

## Fields

| Name |
|  --- |
| `Finished` |
| `BudgetReached` |
| `Timeout` |
| `Cancelled` |
| `InvalidOutput` |
| `InternalError` |

## Example

```csharp
using SeltzApi.Standard.Models;

AgentRunStopReason2 agentRunStopReason2 = AgentRunStopReason2.Finished;
```


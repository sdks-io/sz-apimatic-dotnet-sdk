
# Agent Run Stop Reason

Why a run stopped. `budget_reached` pairs with `completed` when the output
so far is usable and with `failed` when it is not.

## Enumeration

`AgentRunStopReason`

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

AgentRunStopReason agentRunStopReason = AgentRunStopReason.Finished;
```


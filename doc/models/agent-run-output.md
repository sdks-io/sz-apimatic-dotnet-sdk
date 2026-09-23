
# Agent Run Output

A run's output.

*This model accepts additional fields of type object.*

## Structure

`AgentRunOutput`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Grounding` | [`List<AgentRunGrounding>`](../../doc/models/agent-run-grounding.md) | Optional | Per-field citations for `structured`. Empty when there is no structured<br>output. |
| `Sources` | [`List<AgentRunSource>`](../../doc/models/agent-run-source.md) | Optional | The sources cited by `text` or `grounding`, numbered in order of first<br>citation. |
| `Structured` | `object` | Optional | Structured result shaped by the request's `output_schema`. Unset when the<br>request had none. Fields that could not be grounded are expected to be<br>null. On gRPC the object is JSON-encoded. |
| `Text` | `string` | Optional | Cited markdown report. Inline `\[n\]` markers cite the entry of `sources`<br>whose `id` is `n`. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

AgentRunOutput agentRunOutput = new AgentRunOutput
{
    Grounding = new List<AgentRunGrounding>
    {
        null,
        new AgentRunGrounding
        {
        },
    },
    Sources = new List<AgentRunSource>
    {
        null,
    },
    Structured = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
    Text = "text6",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


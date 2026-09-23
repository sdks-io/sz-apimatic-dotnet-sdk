
# Agent Run Grounding

Citations for one field of `output.structured`.

*This model accepts additional fields of type object.*

## Structure

`AgentRunGrounding`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Citations` | [`List<AgentRunCitation>`](../../doc/models/agent-run-citation.md) | Optional | Citations supporting this field's value. |
| `Field` | `string` | Optional | Dot-notation path into the structured output, e.g. "companies.0.ceo". |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

AgentRunGrounding agentRunGrounding = new AgentRunGrounding
{
    Citations = new List<AgentRunCitation>
    {
        null,
        new AgentRunCitation
        {
        },
        new AgentRunCitation
        {
        },
    },
    Field = "field8",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Agent Run Source

One source a run cited.

*This model accepts additional fields of type object.*

## Structure

`AgentRunSource`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `int?` | Optional | Identifier within the run, cited as `\[id\]` in `text` and as `source_id`<br>in `grounding`.<br><br>**Default**: `0`<br><br>**Constraints**: `>= 0` |
| `Url` | `string` | Optional | URL of the source document. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

AgentRunSource agentRunSource = new AgentRunSource
{
    Id = 0,
    Url = "url0",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```



# Agent Run Citation

One citation supporting a grounded field.

*This model accepts additional fields of type object.*

## Structure

`AgentRunCitation`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SourceId` | `int?` | Optional | `id` of the entry in `sources` this citation points at.<br><br>**Default**: `0`<br><br>**Constraints**: `>= 0` |
| `Url` | `string` | Optional | URL of the cited document. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

AgentRunCitation agentRunCitation = new AgentRunCitation
{
    SourceId = 0,
    Url = "url6",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


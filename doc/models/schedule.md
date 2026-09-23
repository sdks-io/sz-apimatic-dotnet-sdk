
# Schedule

*This model accepts additional fields of type object.*

## Structure

`Schedule`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Cadence` | `string` | Required | - |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

Schedule schedule = new Schedule
{
    Cadence = "cadence8",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


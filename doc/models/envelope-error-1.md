
# Envelope Error 1

The error context.

*This model accepts additional fields of type object.*

## Structure

`EnvelopeError1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `string` | Required | The error code. |
| `Message` | `string` | Required | The error message. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

EnvelopeError1 envelopeError1 = new EnvelopeError1
{
    Code = "code4",
    Message = "message4",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


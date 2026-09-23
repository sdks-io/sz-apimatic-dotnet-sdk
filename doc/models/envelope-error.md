
# Envelope Error

The error context. `code` is a stable descriptor in all-caps from a closed
set per endpoint. `message` is a human-readable summary of what went wrong.

*This model accepts additional fields of type object.*

## Structure

`EnvelopeError`

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

EnvelopeError envelopeError = new EnvelopeError
{
    Code = "code2",
    Message = "message4",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


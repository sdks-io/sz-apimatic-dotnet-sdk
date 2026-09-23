
# Create Monitor Response

*This model accepts additional fields of type object.*

## Structure

`CreateMonitorResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Monitor` | [`Monitor`](../../doc/models/monitor.md) | Optional | - |
| `WebhookSecret` | `string` | Optional | Returned once, at create, and never again. Issued whether or not the<br>create supplied a webhook, so keep it. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

CreateMonitorResponse createMonitorResponse = new CreateMonitorResponse
{
    Monitor = null,
    WebhookSecret = "webhook_secret4",
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


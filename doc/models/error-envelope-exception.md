
# Error Envelope Exception

The response body returned for any error.

*This model accepts additional fields of type object.*

## Structure

`ErrorEnvelopeException`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Error` | [`EnvelopeError1`](../../doc/models/envelope-error-1.md) | Required | The error context. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
try
{
    // make the API call
}
catch (ApiException e)
{
    if (e is ErrorEnvelopeException)
    {
        // TODO: Handle ErrorEnvelopeException
        Console.WriteLine(e.Message);
    }
}
```


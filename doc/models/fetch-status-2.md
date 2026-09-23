
# Fetch Status 2

Whether this result carries content.

Branch on this field, never on whether a given content field is present: a
format the page could not produce is unset on an otherwise successful
result, so "markdown is absent" does not mean "the fetch failed".

A failed fetch is still HTTP 200, with the error status on the result.

## Enumeration

`FetchStatus2`

## Fields

| Name |
|  --- |
| `Ok` |
| `Error` |

## Example

```csharp
using SeltzApi.Standard.Models;

FetchStatus2 fetchStatus2 = FetchStatus2.Ok;
```


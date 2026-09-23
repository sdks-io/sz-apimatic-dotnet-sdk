
# Fetch Request

*This model accepts additional fields of type object.*

## Structure

`FetchRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApiKey` | `string` | Optional | API key to access the service. Either this or the `x-api-key` header must<br>be supplied on the HTTP surface; the header takes precedence and is the<br>documented path. On gRPC this field is the only carrier.<br><br>Each URL that comes back with the OK status is billed. A URL that comes<br>back with an error is not. The call is refused up front unless the balance<br>covers the whole batch. |
| `Formats` | `List<string>` | Optional | Representations to return, as documented format names.<br><br>Omitted, or sent empty, means `\["markdown"\]` -- a repeated field carries<br>no presence, so the two are the same request and neither means "no<br>formats".<br><br>Documented names:<br><br>"markdown" -- the main content as Markdown, boilerplate removed.<br><br>An unrecognized name is rejected. |
| `Tier` | `string` | Optional | The service tier, which selects the price. Send `"pro"`. Unset resolves to<br>`"pro"`.<br><br>An unrecognized value is rejected rather than defaulted, because the value<br>selects a price. The name is matched exactly. |
| `TimeoutMs` | `int?` | Optional | Wall-clock budget for one URL, in milliseconds.<br><br>Applies to each URL, not to the batch. A URL that exceeds the budget gets<br>`error.code = "timeout"`; the others in the same request are unaffected.<br><br>Unset means 75000, which is also the maximum; a larger value is served as<br>75000, and a value below 1000 is served as 1000.<br><br>**Constraints**: `>= 0` |
| `Urls` | `List<string>` | Optional | The URLs to fetch. At least one, at most 20.<br><br>An empty list, more than 20 entries, a duplicate entry, a blank or padded<br>entry, or an entry over 2048 bytes is rejected before any billing --<br>duplicates because `FetchResult.requested_url` is the correlation key and<br>a repeated key is ambiguous.<br><br>Everything else is reported inside a `200` as that URL's error result: a<br>value that is not an absolute `http` or `https` URL, a host that does not<br>resolve or that this service will not fetch, an origin that refuses, and a<br>document that is not an HTML page. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

FetchRequest fetchRequest = new FetchRequest
{
    ApiKey = "api_key6",
    Formats = new List<string>
    {
        "formats7",
    },
    Tier = "tier8",
    TimeoutMs = 132,
    Urls = new List<string>
    {
        "urls3",
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


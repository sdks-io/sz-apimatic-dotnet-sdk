
# Search Request

*This model accepts additional fields of type object.*

## Structure

`SearchRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApiKey` | `string` | Optional | API key. On the HTTP surface, either this or the `x-api-key` header must<br>be supplied; the header takes precedence. |
| `ExcludeDomains` | `List<string>` | Optional | Exclude results from these domains |
| `Fields` | [`Fields2`](../../doc/models/fields-2.md) | Optional | - |
| `FromDate` | `string` | Optional | Only include results published on or after this point. UTC throughout.<br><br>A date "2025-10-28", a datetime "2025-10-28T23:00:00" or<br>"2025-10-28T23:00:00Z", or an offset from "now", which is the time the<br>request is served: "now" itself, or "now-" and one duration such as<br>"now-7d" for the past week. A datetime written without a zone is read as<br>UTC, and a date written without a time is the start of that day.<br><br>Offset units are s = second, m = minute, h = hour, d = 24 h, w = 7 d,<br>M = one calendar month and y = one calendar year. A unit and a count are<br>both required, and the case carries meaning.<br><br>A month and a year step the calendar rather than a fixed number of<br>seconds, and the day of the month is clamped to the length of the target<br>month. So "now-1M" from the 31st of March lands on the 28th or 29th of<br>February.<br><br>An offset is a filter, not a freshness guarantee: the corpus refreshes on<br>its own cadence, so a window of an hour or two can return nothing.<br><br>Only a single offset before "now" is accepted. Rounding, several terms in<br>one value, a "+" offset, and any anchor other than "now" are rejected. |
| `IncludeDomains` | `List<string>` | Optional | Include only results from these domains (e.g., \["google.com", "example.com"\]) |
| `MaxResults` | `int?` | Optional | Maximum number of results to return. Defaults to 10. A larger value is<br>served as 1000.<br><br>**Constraints**: `>= 0` |
| `Query` | `string` | Optional | The search query. |
| `Scope` | `string` | Optional | Restricts the results to one vertical or data set.<br><br>Currently available: "news", "wikipedia", "people", "companies".<br><br>When omitted, the default scope is searched. A scope that does not exist,<br>or that this key cannot reach, returns 404. |
| `Tier` | `string` | Optional | How much work goes into ordering the results. It does not change which<br>corpus is searched -- that is `scope` -- so any scope can be requested in<br>either tier.<br><br>`"base"` returns first-stage ranking. `"pro"` adds a ranking stage for<br>higher precision at the top of the list.<br><br>Unset resolves to `"pro"`, so `"base"` is opt-out. A scope with no Pro<br>configuration serves `"pro"` exactly as `"base"` rather than failing, so a<br>caller may always ask for `"pro"`.<br><br>The name is matched without regard to case, and surrounding whitespace is<br>ignored, so "pro", "PRO" and " Pro " are one tier. A name that is neither<br>is rejected rather than defaulted, because the value selects a price. |
| `ToDate` | `string` | Optional | Only include results published on or before this point. UTC throughout.<br><br>A date, a datetime, or an offset from "now", in the same spellings<br>from_date takes. A date written without a time covers the whole of that<br>day, ending at 23:59:59.999; an offset is an instant. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

SearchRequest searchRequest = new SearchRequest
{
    ApiKey = "api_key4",
    ExcludeDomains = new List<string>
    {
        "exclude_domains6",
        "exclude_domains7",
    },
    Fields = null,
    FromDate = "from_date8",
    IncludeDomains = new List<string>
    {
        "include_domains1",
        "include_domains0",
        "include_domains9",
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


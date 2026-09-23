
# Snippet Options

Tuning for snippet selection.

Each option is an upper bound; the response carries at most what is specified here.

The service may hold callers to a tighter bound than the ranges below. A larger
request is then served at that bound rather than refused, which still carries at
most what was specified. Only a value outside the range below is rejected.

*This model accepts additional fields of type object.*

## Structure

`SnippetOptions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MaxSnippets` | `int?` | Optional | Maximum snippets returned across all documents. Accepted range 1-512.<br><br>No default. Left unset, no response-wide ceiling applies at all, which is the<br>recommended setting: `max_snippets_per_result` already bounds every document, so the<br>response is bounded without one.<br><br>This budget is spent one snippet per document at a time, so every document gets its best<br>snippet before any document gets a second. This value is potentially raised to ensure each<br>document can be given at least one snippet.<br><br>**Constraints**: `>= 1`, `<= 512` |
| `MaxSnippetsPerResult` | `int?` | Optional | Maximum snippets from any single document.<br>Defaults to 16, accepted range 1-256.<br><br>**Constraints**: `>= 1`, `<= 256` |
| `MaxTokens` | `int?` | Optional | Ceiling on tokens across all snippets in the response.<br>Defaults to 8192, accepted range 512-65536.<br><br>Spent in the same order as `max_snippets`, one snippet per document at a time, but unlike<br>`max_snippets` this ceiling is not raised to fit `max_results`. Set it low against many<br>results and the budget runs out partway through a round: the documents it does not reach<br>are still returned, with no snippets at all. If every result needs a snippet, raise this<br>or lower `max_results`.<br><br>**Constraints**: `>= 512`, `<= 65536` |
| `MaxTokensPerResult` | `int?` | Optional | Ceiling on tokens of snippets from any single document.<br>Defaults to 4096, accepted range 128-32768.<br><br>**Constraints**: `>= 128`, `<= 32768` |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

SnippetOptions snippetOptions = new SnippetOptions
{
    MaxSnippets = 54,
    MaxSnippetsPerResult = 122,
    MaxTokens = 512,
    MaxTokensPerResult = 218,
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```


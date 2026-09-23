
# Create Agent Run Request

## Structure

`CreateAgentRunRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApiKey` | `string` | Optional | The API key, on gRPC requests. REST reads the `x-api-key` header instead. |
| `Effort` | `string` | Optional | Effort level: how much research the run may do, and its price. One of<br>the configured level names (e.g. `low`, `medium`, `high`, `max`).<br>Omitted = the default level. |
| `OutputSchema` | `object` | Optional | Optional OpenAI-style `response_format` object requesting structured<br>output: `{"type": "text" \| "json_object" \| "json_schema", ...}`, with<br>`name` / `schema` / `strict` for type `json_schema`. A structured type<br>adds `output.structured` and its `grounding` alongside the cited text;<br>type `text` is accepted and requests no structure. On gRPC the object is<br>JSON-encoded. |
| `Query` | `string` | Optional | The natural-language question. Instructions inside the query are<br>followed. |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;

CreateAgentRunRequest createAgentRunRequest = new CreateAgentRunRequest
{
    ApiKey = "api_key6",
    Effort = "effort6",
    OutputSchema = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
    Query = "query6",
};
```


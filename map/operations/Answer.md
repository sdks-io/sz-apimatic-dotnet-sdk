<!-- Generated file — do not edit; regenerated with the SDK. -->

# Answer — operations

Accessor: `client.Answer` · Source: `Api/Answer.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### AnswerInvoke

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `AnswerInvoke(AnswerHttpRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `AnswerHttpResponse`
- **Error**: `SdkException<AnswerError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [400, 401, 402, 404, 405, 408, 413, 415, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AnswerHttpRequest` | `Models/AnswerHttpRequest.cs` |
| `AnswerHttpResponse` | `Models/AnswerHttpResponse.cs` |
| `AnswerError` | `Errors/AnswerError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


<!-- Generated file — do not edit; regenerated with the SDK. -->

# Fetch — operations

Accessor: `client.Fetch` · Source: `Api/Fetch.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### FetchInvoke

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `FetchInvoke(FetchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `FetchResponse`
- **Error**: `SdkException<FetchApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [400, 401, 402, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FetchRequest` | `Models/FetchRequest.cs` |
| `FetchResponse` | `Models/FetchResponse.cs` |
| `FetchApiError` | `Errors/FetchApiError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


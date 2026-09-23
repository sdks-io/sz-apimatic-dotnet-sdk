<!-- Generated file — do not edit; regenerated with the SDK. -->

# Search — operations

Accessor: `client.Search` · Source: `Api/Search.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### SearchInvoke

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `SearchInvoke(SearchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `SearchResponse`
- **Error**: `SdkException<SearchError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [400, 401, 402, 404, 405, 413, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchRequest` | `Models/SearchRequest.cs` |
| `SearchResponse` | `Models/SearchResponse.cs` |
| `SearchError` | `Errors/SearchError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


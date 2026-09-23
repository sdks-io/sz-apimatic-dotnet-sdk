<!-- Generated file — do not edit; regenerated with the SDK. -->

# Records — operations

Accessor: `client.Records` · Source: `Api/Records.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListRecords

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `ListRecords(string monitorId, string? since, string? before, int? limit, bool? includeContent, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`since` … `includeContent`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `since` ← `since`, `before` ← `before`, `limit` ← `limit`, `include_content` ← `includeContent`
- **Returns**: `ListRecordsResponse`
- **Error**: `SdkException<ListRecordsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListRecordsResponse` | `Models/ListRecordsResponse.cs` |
| `ListRecordsError` | `Errors/ListRecordsError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### ListRunRecords

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `ListRunRecords(string monitorId, string runId, string? since, string? before, int? limit, bool? includeContent, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`since` … `includeContent`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `since` ← `since`, `before` ← `before`, `limit` ← `limit`, `include_content` ← `includeContent`
- **Returns**: `ListRunRecordsResponse`
- **Error**: `SdkException<ListRunRecordsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListRunRecordsResponse` | `Models/ListRunRecordsResponse.cs` |
| `ListRunRecordsError` | `Errors/ListRunRecordsError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


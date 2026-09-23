<!-- Generated file — do not edit; regenerated with the SDK. -->

# Runs — operations

Accessor: `client.Runs` · Source: `Api/Runs.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetRun

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `GetRun(string monitorId, string runId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetRunResponse`
- **Error**: `SdkException<GetRunError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetRunResponse` | `Models/GetRunResponse.cs` |
| `GetRunError` | `Errors/GetRunError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### ListRunRequests

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `ListRunRequests(string monitorId, string runId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ListRunRequestsResponse`
- **Error**: `SdkException<ListRunRequestsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListRunRequestsResponse` | `Models/ListRunRequestsResponse.cs` |
| `ListRunRequestsError` | `Errors/ListRunRequestsError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### ListRuns

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `ListRuns(string monitorId, string? since, string? before, int? limit, string? sort, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`since` … `sort`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `since` ← `since`, `before` ← `before`, `limit` ← `limit`, `sort` ← `sort`
- **Returns**: `ListRunsResponse`
- **Error**: `SdkException<ListRunsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListRunsResponse` | `Models/ListRunsResponse.cs` |
| `ListRunsError` | `Errors/ListRunsError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


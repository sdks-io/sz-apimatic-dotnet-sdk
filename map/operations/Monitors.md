<!-- Generated file — do not edit; regenerated with the SDK. -->

# Monitors — operations

Accessor: `client.Monitors` · Source: `Api/Monitors.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateMonitor

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `CreateMonitor(CreateMonitorRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateMonitorResponse`
- **Error**: `SdkException<CreateMonitorError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [400, 401, 409] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateMonitorRequest` | `Models/CreateMonitorRequest.cs` |
| `CreateMonitorResponse` | `Models/CreateMonitorResponse.cs` |
| `CreateMonitorError` | `Errors/CreateMonitorError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### DeleteMonitor

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `DeleteMonitor(string monitorId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `object`
- **Error**: `SdkException<DeleteMonitorError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteMonitorError` | `Errors/DeleteMonitorError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### GetMonitor

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `GetMonitor(string monitorId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetMonitorResponse`
- **Error**: `SdkException<GetMonitorError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMonitorResponse` | `Models/GetMonitorResponse.cs` |
| `GetMonitorError` | `Errors/GetMonitorError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### ListMonitors

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `ListMonitors(string? name, string? status, string? since, string? before, int? limit, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 5 params (`name` … `limit`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `name` ← `name`, `status` ← `status`, `since` ← `since`, `before` ← `before`, `limit` ← `limit`
- **Returns**: `ListMonitorsResponse`
- **Error**: `SdkException<ListMonitorsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [401] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListMonitorsResponse` | `Models/ListMonitorsResponse.cs` |
| `ListMonitorsError` | `Errors/ListMonitorsError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### UpdateMonitor

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `UpdateMonitor(string monitorId, UpdateMonitorRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `UpdateMonitorResponse`
- **Error**: `SdkException<UpdateMonitorError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [404, 409] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateMonitorRequest` | `Models/UpdateMonitorRequest.cs` |
| `UpdateMonitorResponse` | `Models/UpdateMonitorResponse.cs` |
| `UpdateMonitorError` | `Errors/UpdateMonitorError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


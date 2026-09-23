<!-- Generated file — do not edit; regenerated with the SDK. -->

# Agent — operations

Accessor: `client.Agent` · Source: `Api/Agent.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelAgentRun

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `CancelAgentRun(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `AgentRun`
- **Error**: `SdkException<CancelAgentRunError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AgentRun` | `Models/AgentRun.cs` |
| `CancelAgentRunError` | `Errors/CancelAgentRunError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### CreateAgentRun

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `CreateAgentRun(CreateAgentRunRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `AgentRun`
- **Error**: `SdkException<CreateAgentRunError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [400, 401, 402, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateAgentRunRequest` | `Models/CreateAgentRunRequest.cs` |
| `AgentRun` | `Models/AgentRun.cs` |
| `CreateAgentRunError` | `Errors/CreateAgentRunError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### GetAgentRun

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `GetAgentRun(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `AgentRun`
- **Error**: `SdkException<GetAgentRunError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AgentRun` | `Models/AgentRun.cs` |
| `GetAgentRunError` | `Errors/GetAgentRunError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |

### ListAgentRuns

- **Auth**: `options.ApiKeyAuth`
- **Signature**: `ListAgentRuns(long? limit, string? after, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `limit` — nullable, no default → **must pass explicitly**
  - `after` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `limit` ← `limit`, `after` ← `after`
- **Returns**: `ListAgentRunsResponse`
- **Error**: `SdkException<ListAgentRunsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorEnvelope(out ErrorEnvelope)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListAgentRunsResponse` | `Models/ListAgentRunsResponse.cs` |
| `ListAgentRunsError` | `Errors/ListAgentRunsError.cs` |
| `ErrorEnvelope` | `Models/ErrorEnvelope.cs` |


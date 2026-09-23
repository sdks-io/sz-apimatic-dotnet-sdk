# Reference

> Source: [SeltzApiClient](SeltzApiClient.cs)

## Agent

> Source: [Agent](Api/Agent.cs)

<details>
<summary><code>Task&lt;AgentRun&gt; CancelAgentRun(string id, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Stop a run that has not finished. Returns the run, unchanged if it had already ended, so cancelling is safe to retry.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Agent.CancelAgentRun(id);
    // TODO: Handle 'response' of type AgentRun
}
catch (SdkException<CancelAgentRunError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The run id. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AgentRun](Models/AgentRun.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelAgentRunError](Errors/CancelAgentRunError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AgentRun&gt; CreateAgentRun(CreateAgentRunRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the new run in `pending` state. Poll it by id until `status` reaches a terminal state.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Agent.CreateAgentRun(body);
    // TODO: Handle 'response' of type AgentRun
}
catch (SdkException<CreateAgentRunError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateAgentRunRequest](Models/CreateAgentRunRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AgentRun](Models/AgentRun.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateAgentRunError](Errors/CreateAgentRunError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AgentRun&gt; GetAgentRun(string id, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Poll until `status` reaches a terminal state.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Agent.GetAgentRun(id);
    // TODO: Handle 'response' of type AgentRun
}
catch (SdkException<GetAgentRunError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>id</code> | <code>string</code> | The run id. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AgentRun](Models/AgentRun.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAgentRunError](Errors/GetAgentRunError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListAgentRunsResponse&gt; ListAgentRuns(long? limit, string? after, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The organization's runs, newest first. Pass one page's `next` as the following request's `after`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Agent.ListAgentRuns(limit, after);
    // TODO: Handle 'response' of type ListAgentRunsResponse
}
catch (SdkException<ListAgentRunsError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>limit</code> | <code>long?</code> | Page size, 1-100. Defaults to 20. |
| <code>after</code> | <code>string?</code> | Pagination cursor: the previous page's `next`. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListAgentRunsResponse](Models/ListAgentRunsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListAgentRunsError](Errors/ListAgentRunsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Answer

> Source: [Answer](Api/Answer.cs)

<details>
<summary><code>Task&lt;AnswerHttpResponse&gt; AnswerInvoke(AnswerHttpRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Answer.AnswerInvoke(body);
    // TODO: Handle 'response' of type AnswerHttpResponse
}
catch (SdkException<AnswerError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[AnswerHttpRequest](Models/AnswerHttpRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AnswerHttpResponse](Models/AnswerHttpResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AnswerError](Errors/AnswerError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Fetch

> Source: [Fetch](Api/Fetch.cs)

<details>
<summary><code>Task&lt;FetchResponse&gt; FetchInvoke(FetchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Fetch.FetchInvoke(body);
    // TODO: Handle 'response' of type FetchResponse
}
catch (SdkException<FetchApiError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[FetchRequest](Models/FetchRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FetchResponse](Models/FetchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[FetchApiError](Errors/FetchApiError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Monitors

> Source: [Monitors](Api/Monitors.cs)

<details>
<summary><code>Task&lt;CreateMonitorResponse&gt; CreateMonitor(CreateMonitorRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Monitors.CreateMonitor(body);
    // TODO: Handle 'response' of type CreateMonitorResponse
}
catch (SdkException<CreateMonitorError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateMonitorRequest](Models/CreateMonitorRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateMonitorResponse](Models/CreateMonitorResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateMonitorError](Errors/CreateMonitorError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; DeleteMonitor(string monitorId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Monitors.DeleteMonitor(monitorId);
    // TODO: Handle 'response' of type object
}
catch (SdkException<DeleteMonitorError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteMonitorError](Errors/DeleteMonitorError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetMonitorResponse&gt; GetMonitor(string monitorId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Monitors.GetMonitor(monitorId);
    // TODO: Handle 'response' of type GetMonitorResponse
}
catch (SdkException<GetMonitorError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetMonitorResponse](Models/GetMonitorResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetMonitorError](Errors/GetMonitorError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListMonitorsResponse&gt; ListMonitors(string? name, string? status, string? since, string? before, int? limit, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Monitors.ListMonitors(name, status, since, before, limit);
    // TODO: Handle 'response' of type ListMonitorsResponse
}
catch (SdkException<ListMonitorsError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>name</code> | <code>string?</code> | Matches a monitor whose name is exactly this. |
| <code>status</code> | <code>string?</code> | One of `active`, `paused`, `disabled`. `deleted` is not a filter: a<br>deleted monitor is invisible. |
| <code>since</code> | <code>string?</code> | Exclusive lower bound: the `monitor_id` of a monitor to start after. |
| <code>before</code> | <code>string?</code> | Exclusive upper bound. The list is newest first, so page forward with<br>the `monitor_id` of the last monitor on the previous page. |
| <code>limit</code> | <code>int?</code> | Defaults to 100, at most 1,000. A short page is normal: a page ends at<br>`limit` or at the byte budget, whichever binds first. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListMonitorsResponse](Models/ListMonitorsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListMonitorsError](Errors/ListMonitorsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateMonitorResponse&gt; UpdateMonitor(string monitorId, UpdateMonitorRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Monitors.UpdateMonitor(monitorId, body);
    // TODO: Handle 'response' of type UpdateMonitorResponse
}
catch (SdkException<UpdateMonitorError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |
| <code>body</code> | <code>[UpdateMonitorRequest](Models/UpdateMonitorRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateMonitorResponse](Models/UpdateMonitorResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateMonitorError](Errors/UpdateMonitorError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Records

> Source: [Records](Api/Records.cs)

<details>
<summary><code>Task&lt;ListRecordsResponse&gt; ListRecords(string monitorId, string? since, string? before, int? limit, bool? includeContent, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Records.ListRecords(monitorId, since, before, limit, includeContent);
    // TODO: Handle 'response' of type ListRecordsResponse
}
catch (SdkException<ListRecordsError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |
| <code>since</code> | <code>string?</code> | Exclusive lower bound on `record_id`. |
| <code>before</code> | <code>string?</code> | Exclusive upper bound on `record_id`. |
| <code>limit</code> | <code>int?</code> | Defaults to 100, at most 1,000. A short page is normal: a page ends at<br>`limit` or at the byte budget, whichever binds first. |
| <code>includeContent</code> | <code>bool?</code> | Include each record's document content. Defaults to true. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListRecordsResponse](Models/ListRecordsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListRecordsError](Errors/ListRecordsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListRunRecordsResponse&gt; ListRunRecords(string monitorId, string runId, string? since, string? before, int? limit, bool? includeContent, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Exists so that no consumer does arithmetic on a record id: a webhook carries a run's record range as a bound, not a dense sequence.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Records.ListRunRecords(monitorId, runId, since, before, limit, includeContent);
    // TODO: Handle 'response' of type ListRunRecordsResponse
}
catch (SdkException<ListRunRecordsError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |
| <code>runId</code> | <code>string</code> | - |
| <code>since</code> | <code>string?</code> | Exclusive lower bound on `record_id`. |
| <code>before</code> | <code>string?</code> | Exclusive upper bound on `record_id`. |
| <code>limit</code> | <code>int?</code> | Defaults to 100, at most 1,000. A short page is normal: a page ends at<br>`limit` or at the byte budget, whichever binds first. |
| <code>includeContent</code> | <code>bool?</code> | Include each record's document content. Defaults to true. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListRunRecordsResponse](Models/ListRunRecordsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListRunRecordsError](Errors/ListRunRecordsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Runs

> Source: [Runs](Api/Runs.cs)

<details>
<summary><code>Task&lt;GetRunResponse&gt; GetRun(string monitorId, string runId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Runs.GetRun(monitorId, runId);
    // TODO: Handle 'response' of type GetRunResponse
}
catch (SdkException<GetRunError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |
| <code>runId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetRunResponse](Models/GetRunResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetRunError](Errors/GetRunError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListRunRequestsResponse&gt; ListRunRequests(string monitorId, string runId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The only place a customer can tell *this query failed* from *there was genuinely nothing new*: records are a stream of positives, and absence cannot be inferred from presences.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Runs.ListRunRequests(monitorId, runId);
    // TODO: Handle 'response' of type ListRunRequestsResponse
}
catch (SdkException<ListRunRequestsError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |
| <code>runId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListRunRequestsResponse](Models/ListRunRequestsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListRunRequestsError](Errors/ListRunRequestsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListRunsResponse&gt; ListRuns(string monitorId, string? since, string? before, int? limit, string? sort, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Runs.ListRuns(monitorId, since, before, limit, sort);
    // TODO: Handle 'response' of type ListRunsResponse
}
catch (SdkException<ListRunsError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>monitorId</code> | <code>string</code> | - |
| <code>since</code> | <code>string?</code> | Exclusive lower bound on `run_id`. |
| <code>before</code> | <code>string?</code> | Exclusive upper bound on `run_id`. |
| <code>limit</code> | <code>int?</code> | Defaults to 100, at most 1,000. |
| <code>sort</code> | <code>string?</code> | `desc` (the default, newest first) or `asc`. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListRunsResponse](Models/ListRunsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListRunsError](Errors/ListRunsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Search

> Source: [Search](Api/Search.cs)

<details>
<summary><code>Task&lt;SearchResponse&gt; SearchInvoke(SearchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Search.SearchInvoke(body);
    // TODO: Handle 'response' of type SearchResponse
}
catch (SdkException<SearchError> ex)
{
    if (ex.Error.TryGetErrorEnvelope(out var error))
    {
        // TODO: Handle 'error' of type ErrorEnvelope
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[SearchRequest](Models/SearchRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SearchResponse](Models/SearchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchError](Errors/SearchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>


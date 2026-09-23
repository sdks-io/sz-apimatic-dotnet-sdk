# Agent

Agent runs: create, poll, list, cancel

```csharp
AgentApi agentApi = client.AgentApi;
```

## Class Name

`AgentApi`

## Methods

* [List Agent Runs](../../doc/controllers/agent.md#list-agent-runs)
* [Create Agent Run](../../doc/controllers/agent.md#create-agent-run)
* [Get Agent Run](../../doc/controllers/agent.md#get-agent-run)
* [Cancel Agent Run](../../doc/controllers/agent.md#cancel-agent-run)


# List Agent Runs

The organization's runs, newest first. Pass one page's `next` as the following request's `after`.

```csharp
ListAgentRunsAsync(
    long? limit = null,
    string after = null)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `long?` | Query, Optional | Page size, 1-100. Defaults to 20. |
| `after` | `string` | Query, Optional | Pagination cursor: the previous page's `next`. |

## Response Type

**200**: One page of runs, newest first.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ListAgentRunsResponse](../../doc/models/list-agent-runs-response.md).

## Example Usage

```csharp
try
{
    ApiResponse<ListAgentRunsResponse> result = await agentApi.ListAgentRunsAsync();
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
    if (e is ErrorEnvelopeException)
    {
       // TODO: Handle ErrorEnvelopeException exception here
    }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Malformed or unknown query parameter. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 401 | Invalid or missing API key. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 404 | Unknown `after` cursor. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 500 | Unexpected server error. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


# Create Agent Run

Returns the new run in `pending` state. Poll it by id until `status` reaches a terminal state.

```csharp
CreateAgentRunAsync(
    Models.CreateAgentRunRequest body)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateAgentRunRequest`](../../doc/models/create-agent-run-request.md) | Body, Required | - |

## Response Type

**201**: The new run, in `pending` state.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.AgentRun](../../doc/models/agent-run.md).

## Example Usage

```csharp
CreateAgentRunRequest body = new CreateAgentRunRequest
{
};

try
{
    ApiResponse<AgentRun> result = await agentApi.CreateAgentRunAsync(body);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
    if (e is ErrorEnvelopeException)
    {
       // TODO: Handle ErrorEnvelopeException exception here
    }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Malformed body, unknown field, unknown `effort`, or a rejected `output_schema`. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 401 | Invalid or missing API key. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 402 | Insufficient credits. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 500 | Unexpected server error. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


# Get Agent Run

Poll until `status` reaches a terminal state.

```csharp
GetAgentRunAsync(
    string id)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The run id. |

## Response Type

**200**: The run.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.AgentRun](../../doc/models/agent-run.md).

## Example Usage

```csharp
string id = "id0";
try
{
    ApiResponse<AgentRun> result = await agentApi.GetAgentRunAsync(id);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
    if (e is ErrorEnvelopeException)
    {
       // TODO: Handle ErrorEnvelopeException exception here
    }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Invalid or missing API key. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 404 | No such run in this org. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 500 | Unexpected server error. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


# Cancel Agent Run

Stop a run that has not finished. Returns the run, unchanged if it had already ended, so cancelling is safe to retry.

```csharp
CancelAgentRunAsync(
    string id)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The run id. |

## Response Type

**200**: The run.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.AgentRun](../../doc/models/agent-run.md).

## Example Usage

```csharp
string id = "id0";
try
{
    ApiResponse<AgentRun> result = await agentApi.CancelAgentRunAsync(id);
}
catch (ApiException e)
{
    Console.WriteLine(e.Message);
    if (e is ErrorEnvelopeException)
    {
       // TODO: Handle ErrorEnvelopeException exception here
    }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Invalid or missing API key. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 404 | No such run in this org. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 500 | Unexpected server error. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


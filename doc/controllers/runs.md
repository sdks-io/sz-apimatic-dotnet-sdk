# Runs

Run history and per-request outcomes

```csharp
RunsApi runsApi = client.RunsApi;
```

## Class Name

`RunsApi`

## Methods

* [List Runs](../../doc/controllers/runs.md#list-runs)
* [Get Run](../../doc/controllers/runs.md#get-run)
* [List Run Requests](../../doc/controllers/runs.md#list-run-requests)


# List Runs

```csharp
ListRunsAsync(
    string monitorId,
    string since = null,
    string before = null,
    int? limit = null,
    string sort = null)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |
| `since` | `string` | Query, Optional | Exclusive lower bound on `run_id`. |
| `before` | `string` | Query, Optional | Exclusive upper bound on `run_id`. |
| `limit` | `int?` | Query, Optional | Defaults to 100, at most 1,000. |
| `sort` | `string` | Query, Optional | `desc` (the default, newest first) or `asc`. |

## Response Type

**200**: A page of runs.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ListRunsResponse](../../doc/models/list-runs-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
try
{
    ApiResponse<ListRunsResponse> result = await runsApi.ListRunsAsync(monitorId);
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
| 404 | No such monitor in this org. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


# Get Run

```csharp
GetRunAsync(
    string monitorId,
    string runId)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |
| `runId` | `string` | Template, Required | - |

## Response Type

**200**: The run. Carries no records and no breakdown.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.GetRunResponse](../../doc/models/get-run-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
string runId = "run_id8";
try
{
    ApiResponse<GetRunResponse> result = await runsApi.GetRunAsync(
        monitorId,
        runId
    );
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
| 404 | No such run on this monitor. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


# List Run Requests

The only place a customer can tell *this query failed* from *there was genuinely nothing new*: records are a stream of positives, and absence cannot be inferred from presences.

```csharp
ListRunRequestsAsync(
    string monitorId,
    string runId)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |
| `runId` | `string` | Template, Required | - |

## Response Type

**200**: That run's per-request outcomes.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ListRunRequestsResponse](../../doc/models/list-run-requests-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
string runId = "run_id8";
try
{
    ApiResponse<ListRunRequestsResponse> result = await runsApi.ListRunRequestsAsync(
        monitorId,
        runId
    );
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
| 404 | No such run on this monitor. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


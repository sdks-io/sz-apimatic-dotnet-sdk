# Monitors

Monitor configuration

```csharp
MonitorsApi monitorsApi = client.MonitorsApi;
```

## Class Name

`MonitorsApi`

## Methods

* [List Monitors](../../doc/controllers/monitors.md#list-monitors)
* [Create Monitor](../../doc/controllers/monitors.md#create-monitor)
* [Get Monitor](../../doc/controllers/monitors.md#get-monitor)
* [Delete Monitor](../../doc/controllers/monitors.md#delete-monitor)
* [Update Monitor](../../doc/controllers/monitors.md#update-monitor)


# List Monitors

```csharp
ListMonitorsAsync(
    string name = null,
    string status = null,
    string since = null,
    string before = null,
    int? limit = null)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Query, Optional | Matches a monitor whose name is exactly this. |
| `status` | `string` | Query, Optional | One of `active`, `paused`, `disabled`. `deleted` is not a filter: a<br>deleted monitor is invisible. |
| `since` | `string` | Query, Optional | Exclusive lower bound: the `monitor_id` of a monitor to start after. |
| `before` | `string` | Query, Optional | Exclusive upper bound. The list is newest first, so page forward with<br>the `monitor_id` of the last monitor on the previous page. |
| `limit` | `int?` | Query, Optional | Defaults to 100, at most 1,000. A short page is normal: a page ends at<br>`limit` or at the byte budget, whichever binds first. |

## Response Type

**200**: The org's monitors.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ListMonitorsResponse](../../doc/models/list-monitors-response.md).

## Example Usage

```csharp
try
{
    ApiResponse<ListMonitorsResponse> result = await monitorsApi.ListMonitorsAsync();
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


# Create Monitor

```csharp
CreateMonitorAsync(
    Models.CreateMonitorRequest body)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateMonitorRequest`](../../doc/models/create-monitor-request.md) | Body, Required | - |

## Response Type

**201**: Created. `webhook_secret` is returned once and never again.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.CreateMonitorResponse](../../doc/models/create-monitor-response.md).

## Example Usage

```csharp
CreateMonitorRequest body = new CreateMonitorRequest
{
    Cadence = "cadence2",
};

try
{
    ApiResponse<CreateMonitorResponse> result = await monitorsApi.CreateMonitorAsync(body);
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
| 400 | Missing or malformed fields. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 401 | Invalid or missing API key. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 409 | That name is already taken in this org. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


# Get Monitor

```csharp
GetMonitorAsync(
    string monitorId)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |

## Response Type

**200**: The monitor.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.GetMonitorResponse](../../doc/models/get-monitor-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
try
{
    ApiResponse<GetMonitorResponse> result = await monitorsApi.GetMonitorAsync(monitorId);
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


# Delete Monitor

```csharp
DeleteMonitorAsync(
    string monitorId)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |

## Response Type

**200**: Deleted. Every record becomes invisible at once.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type object.

## Example Usage

```csharp
string monitorId = "monitor_id2";
try
{
    ApiResponse<object> result = await monitorsApi.DeleteMonitorAsync(monitorId);
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


# Update Monitor

```csharp
UpdateMonitorAsync(
    string monitorId,
    Models.UpdateMonitorRequest body)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |
| `body` | [`UpdateMonitorRequest`](../../doc/models/update-monitor-request.md) | Body, Required | - |

## Response Type

**200**: Updated.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.UpdateMonitorResponse](../../doc/models/update-monitor-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
UpdateMonitorRequest body = new UpdateMonitorRequest
{
    Cadence = "cadence2",
};

try
{
    ApiResponse<UpdateMonitorResponse> result = await monitorsApi.UpdateMonitorAsync(
        monitorId,
        body
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
| 404 | No such monitor in this org. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 409 | That name is already taken in this org. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


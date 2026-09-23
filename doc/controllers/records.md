# Records

The delivered records

```csharp
RecordsApi recordsApi = client.RecordsApi;
```

## Class Name

`RecordsApi`

## Methods

* [List Records](../../doc/controllers/records.md#list-records)
* [List Run Records](../../doc/controllers/records.md#list-run-records)


# List Records

```csharp
ListRecordsAsync(
    string monitorId,
    string since = null,
    string before = null,
    int? limit = null,
    bool? includeContent = null)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |
| `since` | `string` | Query, Optional | Exclusive lower bound on `record_id`. |
| `before` | `string` | Query, Optional | Exclusive upper bound on `record_id`. |
| `limit` | `int?` | Query, Optional | Defaults to 100, at most 1,000. A short page is normal: a page ends at<br>`limit` or at the byte budget, whichever binds first. |
| `includeContent` | `bool?` | Query, Optional | Include each record's document content. Defaults to true. |

## Response Type

**200**: A page of records.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ListRecordsResponse](../../doc/models/list-records-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
try
{
    ApiResponse<ListRecordsResponse> result = await recordsApi.ListRecordsAsync(monitorId);
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


# List Run Records

Exists so that no consumer does arithmetic on a record id: a webhook carries a run's record range as a bound, not a dense sequence.

```csharp
ListRunRecordsAsync(
    string monitorId,
    string runId,
    string since = null,
    string before = null,
    int? limit = null,
    bool? includeContent = null)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `monitorId` | `string` | Template, Required | - |
| `runId` | `string` | Template, Required | - |
| `since` | `string` | Query, Optional | Exclusive lower bound on `record_id`. |
| `before` | `string` | Query, Optional | Exclusive upper bound on `record_id`. |
| `limit` | `int?` | Query, Optional | Defaults to 100, at most 1,000. A short page is normal: a page ends at<br>`limit` or at the byte budget, whichever binds first. |
| `includeContent` | `bool?` | Query, Optional | Include each record's document content. Defaults to true. |

## Response Type

**200**: A page of that run's records.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ListRunRecordsResponse](../../doc/models/list-run-records-response.md).

## Example Usage

```csharp
string monitorId = "monitor_id2";
string runId = "run_id8";
try
{
    ApiResponse<ListRunRecordsResponse> result = await recordsApi.ListRunRecordsAsync(
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


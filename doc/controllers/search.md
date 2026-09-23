# Search

Search operations

```csharp
SearchApi searchApi = client.SearchApi;
```

## Class Name

`SearchApi`


# Search

```csharp
SearchAsync(
    Models.SearchRequest body)
```

## Authentication

This endpoint requires [ApiKeyAuth](../../doc/auth/custom-header-signature.md)

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchRequest`](../../doc/models/search-request.md) | Body, Required | - |

## Response Type

**200**: Search completed. Returns matched documents.

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.SearchResponse](../../doc/models/search-response.md).

## Example Usage

```csharp
SearchRequest body = new SearchRequest
{
    Query = "How much is the fish?",
};

try
{
    ApiResponse<SearchResponse> result = await searchApi.SearchAsync(body);
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
| 400 | Missing or malformed request fields. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 401 | Invalid or missing API key. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 402 | Insufficient credits. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 404 | Endpoint not found, or a scope that matches nothing. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 405 | Wrong method for this endpoint. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 413 | Request body is too large. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 429 | Rate limit exceeded. Wait before retrying. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |
| 500 | Unexpected server error. | [`ErrorEnvelopeException`](../../doc/models/error-envelope-exception.md) |


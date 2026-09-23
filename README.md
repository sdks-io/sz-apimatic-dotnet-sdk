
# Getting Started with Seltz API

## Introduction

REST API for the Seltz platform: context retrieval (`/v1/search`), RAG answers (`/v1/answer`), monitors (`/v1/monitors`), and page fetching (`/v1/fetch`).

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package SzApimaticSDK --version 0.0.1
```

You can also view the package at:
https://www.nuget.org/packages/SzApimaticSDK/0.0.1

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| Timeout | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(30)` |
| HttpClientConfiguration | [`Action<HttpClientConfiguration.Builder>`](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-client-configuration-builder.md) | Action delegate that configures the HTTP client by using the HttpClientConfiguration.Builder for customizing API call settings.<br>*Default*: `new HttpClient()` |
| LogBuilder | [`LogBuilder`](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/log-builder.md) | Represents the logging configuration builder for API calls |
| CustomHeaderAuthenticationCredentials | [`CustomHeaderAuthenticationCredentials`](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/auth/custom-header-signature.md) | The Credentials Setter for Custom Header Signature |

The API client can be initialized as follows:

### Code-Based Initialization

```csharp
using Microsoft.Extensions.Logging;
using SeltzApi.Standard;
using SeltzApi.Standard.Authentication;

namespace ConsoleApp;

SeltzApiClient client = new SeltzApiClient.Builder()
    .CustomHeaderAuthenticationCredentials(
        new CustomHeaderAuthenticationModel.Builder(
            "x-api-key"
        )
        .Build())
    .HttpClientConfig(httpClientConfig =>
        httpClientConfig.Timeout(TimeSpan.FromSeconds(100)))
    .LoggingConfig(config => config
        .LogLevel(LogLevel.Information)
        .RequestConfig(reqConfig => reqConfig.Body(true))
        .ResponseConfig(respConfig => respConfig.Headers(true))
    )
    .Build();
```

### Configuration-Based Initialization

```csharp
using SeltzApi.Standard;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp;

// Build the IConfiguration using .NET conventions (JSON, environment, etc.)
var configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .AddEnvironmentVariables() // [optional] read environment variables
    .Build();

// Instantiate your SDK and configure it from IConfiguration
var client = SeltzApiClient
    .FromConfiguration(configuration.GetSection("SeltzApi"));
```

See the [Configuration-Based Initialization](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/configuration-based-initialization.md) section for details.

## Authorization

This API uses the following authentication schemes.

* [`ApiKeyAuth (Custom Header Signature)`](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/auth/custom-header-signature.md)

## List of APIs

* [Search](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/search.md)
* [Answer](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/answer.md)
* [Monitors](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/monitors.md)
* [Records](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/records.md)
* [Runs](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/runs.md)
* [Agent](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/agent.md)
* [Fetch](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/controllers/fetch.md)

## SDK Infrastructure

### Configuration

* [Configuration-Based Initialization](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/configuration-based-initialization.md)
* [HttpClientConfiguration](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-client-configuration.md)
* [HttpClientConfigurationBuilder](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-client-configuration-builder.md)
* [LogBuilder](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/log-builder.md)
* [LogRequestBuilder](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/log-request-builder.md)
* [LogResponseBuilder](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/log-response-builder.md)
* [ProxyConfigurationBuilder](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/proxy-configuration-builder.md)

### HTTP

* [HttpCallback](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-callback.md)
* [HttpContext](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-context.md)
* [HttpRequest](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-request.md)
* [HttpResponse](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/http-string-response.md)

### Utilities

* [ApiException](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/api-exception.md)
* [ApiResponse](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/api-response.md)
* [ApiHelper](https://www.github.com/sdks-io/sz-apimatic-dotnet-sdk/tree/0.0.1/doc/api-helper.md)


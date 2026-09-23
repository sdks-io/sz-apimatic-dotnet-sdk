
# Custom Header Signature



Documentation for accessing and setting credentials for ApiKeyAuth.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| XApiKey | `string` | Seltz API key. Create one in the [Seltz Console](https://console.seltz.ai/api-keys) under **Settings → API Keys**. | `XApiKey` | `XApiKey` |



**Note:** Auth credentials can be set using `CustomHeaderAuthenticationCredentials` in the client builder and accessed through `CustomHeaderAuthenticationCredentials` method in the client instance.

## Usage Example

### Client Initialization

You must provide credentials in the client as shown in the following code snippet.

```csharp
using SeltzApi.Standard;
using SeltzApi.Standard.Authentication;

namespace ConsoleApp;

SeltzApiClient client = new SeltzApiClient.Builder()
    .CustomHeaderAuthenticationCredentials(
        new CustomHeaderAuthenticationModel.Builder(
            "x-api-key"
        )
        .Build())
    .Build();
```



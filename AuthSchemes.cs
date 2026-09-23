using SeltzApi.Core.Authentication;
using SeltzApi.Core.Authentication.ApiKey;

namespace SeltzApi;

internal sealed class AuthSchemes
{
    public IAuthScheme ApiKeyAuth { get; }

    public AuthSchemes(SeltzApiClientOptions options)
    {
        ApiKeyAuth = ApiKeyHeaderScheme.Create("x-api-key", options.ApiKeyAuth);
    }
}

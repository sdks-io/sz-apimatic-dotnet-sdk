using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class FetchApiError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private FetchApiError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static FetchApiError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static FetchApiError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<FetchApiError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 402 or 429 or 500 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class FetchApiErrorResponse : IErrorResponse<FetchApiError>
{
    public static FetchApiErrorResponse Instance { get; } = new();

    private FetchApiErrorResponse()
    {
    }

    public Task<FetchApiError> Map(HttpResponseMessage response, CancellationToken ct) =>
        FetchApiError.Create(response, ct);
}

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class SearchError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private SearchError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static SearchError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static SearchError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<SearchError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 402 or 404 or 405 or 413 or 429 or 500 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchErrorResponse : IErrorResponse<SearchError>
{
    public static SearchErrorResponse Instance { get; } = new();

    private SearchErrorResponse()
    {
    }

    public Task<SearchError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchError.Create(response, ct);
}

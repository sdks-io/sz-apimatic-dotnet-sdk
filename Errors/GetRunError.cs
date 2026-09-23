using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class GetRunError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private GetRunError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static GetRunError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static GetRunError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<GetRunError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetRunErrorResponse : IErrorResponse<GetRunError>
{
    public static GetRunErrorResponse Instance { get; } = new();

    private GetRunErrorResponse()
    {
    }

    public Task<GetRunError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetRunError.Create(response, ct);
}

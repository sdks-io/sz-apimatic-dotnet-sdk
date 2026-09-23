using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class GetMonitorError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private GetMonitorError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static GetMonitorError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static GetMonitorError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<GetMonitorError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetMonitorErrorResponse : IErrorResponse<GetMonitorError>
{
    public static GetMonitorErrorResponse Instance { get; } = new();

    private GetMonitorErrorResponse()
    {
    }

    public Task<GetMonitorError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetMonitorError.Create(response, ct);
}

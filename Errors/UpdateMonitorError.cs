using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class UpdateMonitorError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private UpdateMonitorError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static UpdateMonitorError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static UpdateMonitorError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<UpdateMonitorError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 or 409 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdateMonitorErrorResponse : IErrorResponse<UpdateMonitorError>
{
    public static UpdateMonitorErrorResponse Instance { get; } = new();

    private UpdateMonitorErrorResponse()
    {
    }

    public Task<UpdateMonitorError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdateMonitorError.Create(response, ct);
}

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class DeleteMonitorError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private DeleteMonitorError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static DeleteMonitorError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static DeleteMonitorError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<DeleteMonitorError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteMonitorErrorResponse : IErrorResponse<DeleteMonitorError>
{
    public static DeleteMonitorErrorResponse Instance { get; } = new();

    private DeleteMonitorErrorResponse()
    {
    }

    public Task<DeleteMonitorError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteMonitorError.Create(response, ct);
}

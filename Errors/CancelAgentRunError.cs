using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class CancelAgentRunError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private CancelAgentRunError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static CancelAgentRunError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static CancelAgentRunError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<CancelAgentRunError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            401 or 404 or 500 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CancelAgentRunErrorResponse : IErrorResponse<CancelAgentRunError>
{
    public static CancelAgentRunErrorResponse Instance { get; } = new();

    private CancelAgentRunErrorResponse()
    {
    }

    public Task<CancelAgentRunError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CancelAgentRunError.Create(response, ct);
}

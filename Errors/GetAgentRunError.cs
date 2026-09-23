using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class GetAgentRunError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private GetAgentRunError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static GetAgentRunError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static GetAgentRunError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<GetAgentRunError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            401 or 404 or 500 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetAgentRunErrorResponse : IErrorResponse<GetAgentRunError>
{
    public static GetAgentRunErrorResponse Instance { get; } = new();

    private GetAgentRunErrorResponse()
    {
    }

    public Task<GetAgentRunError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetAgentRunError.Create(response, ct);
}

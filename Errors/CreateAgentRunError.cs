using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class CreateAgentRunError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private CreateAgentRunError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static CreateAgentRunError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static CreateAgentRunError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<CreateAgentRunError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 402 or 500 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateAgentRunErrorResponse : IErrorResponse<CreateAgentRunError>
{
    public static CreateAgentRunErrorResponse Instance { get; } = new();

    private CreateAgentRunErrorResponse()
    {
    }

    public Task<CreateAgentRunError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateAgentRunError.Create(response, ct);
}

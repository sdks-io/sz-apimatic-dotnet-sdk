using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class ListAgentRunsError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private ListAgentRunsError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static ListAgentRunsError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static ListAgentRunsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<ListAgentRunsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 404 or 500 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListAgentRunsErrorResponse : IErrorResponse<ListAgentRunsError>
{
    public static ListAgentRunsErrorResponse Instance { get; } = new();

    private ListAgentRunsErrorResponse()
    {
    }

    public Task<ListAgentRunsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListAgentRunsError.Create(response, ct);
}

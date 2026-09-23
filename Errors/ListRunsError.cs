using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class ListRunsError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private ListRunsError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static ListRunsError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static ListRunsError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<ListRunsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListRunsErrorResponse : IErrorResponse<ListRunsError>
{
    public static ListRunsErrorResponse Instance { get; } = new();

    private ListRunsErrorResponse()
    {
    }

    public Task<ListRunsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListRunsError.Create(response, ct);
}

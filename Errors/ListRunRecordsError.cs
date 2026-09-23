using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class ListRunRecordsError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private ListRunRecordsError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static ListRunRecordsError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static ListRunRecordsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<ListRunRecordsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListRunRecordsErrorResponse : IErrorResponse<ListRunRecordsError>
{
    public static ListRunRecordsErrorResponse Instance { get; } = new();

    private ListRunRecordsErrorResponse()
    {
    }

    public Task<ListRunRecordsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListRunRecordsError.Create(response, ct);
}

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class ListRecordsError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private ListRecordsError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static ListRecordsError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static ListRecordsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<ListRecordsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            404 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListRecordsErrorResponse : IErrorResponse<ListRecordsError>
{
    public static ListRecordsErrorResponse Instance { get; } = new();

    private ListRecordsErrorResponse()
    {
    }

    public Task<ListRecordsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListRecordsError.Create(response, ct);
}

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class ListMonitorsError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private ListMonitorsError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static ListMonitorsError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static ListMonitorsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<ListMonitorsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            401 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListMonitorsErrorResponse : IErrorResponse<ListMonitorsError>
{
    public static ListMonitorsErrorResponse Instance { get; } = new();

    private ListMonitorsErrorResponse()
    {
    }

    public Task<ListMonitorsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListMonitorsError.Create(response, ct);
}

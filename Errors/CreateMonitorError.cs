using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class CreateMonitorError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private CreateMonitorError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static CreateMonitorError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static CreateMonitorError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<CreateMonitorError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 409 => FromJson<ErrorEnvelope>(response, ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateMonitorErrorResponse : IErrorResponse<CreateMonitorError>
{
    public static CreateMonitorErrorResponse Instance { get; } = new();

    private CreateMonitorErrorResponse()
    {
    }

    public Task<CreateMonitorError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateMonitorError.Create(response, ct);
}

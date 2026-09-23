using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core.ErrorResponse;
using SeltzApi.Core.Models;
using SeltzApi.Models;

namespace SeltzApi.Errors;

public sealed class AnswerError : ApiError
{
    private readonly Optional<ErrorEnvelope> _errorEnvelopeValue;

    private AnswerError(Optional<ErrorEnvelope> errorEnvelopeValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorEnvelopeValue = errorEnvelopeValue;
    }

    private static AnswerError AsErrorEnvelope(ErrorEnvelope value) =>
        new(Optional<ErrorEnvelope>.Some(value), default);

    private static AnswerError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorEnvelope(out ErrorEnvelope value) => _errorEnvelopeValue.TryGetValue(out value);

    internal static Task<AnswerError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 402 or 404 or 405 or 408 or 413 or 415 or 429 or 500 => FromJson<ErrorEnvelope>(response,
                ct).As(AsErrorEnvelope),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class AnswerErrorResponse : IErrorResponse<AnswerError>
{
    public static AnswerErrorResponse Instance { get; } = new();

    private AnswerErrorResponse()
    {
    }

    public Task<AnswerError> Map(HttpResponseMessage response, CancellationToken ct) =>
        AnswerError.Create(response, ct);
}

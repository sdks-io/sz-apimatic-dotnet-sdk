using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SeltzApi.Core;
using SeltzApi.Core.Exceptions;
using SeltzApi.Core.Models;
using SeltzApi.Core.Request;
using SeltzApi.Core.Response;
using SeltzApi.Errors;
using SeltzApi.Models;

namespace SeltzApi.Api;

/// <summary>
/// Answer operations
/// </summary>
public sealed class Answer
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Answer(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Answer a query with RAG over search results
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AnswerHttpResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AnswerError"/> when the server returns an error response.</exception>
    public Task<AnswerHttpResponse> AnswerInvoke(AnswerHttpRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/answer"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<AnswerHttpResponse>(),
            AnswerErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);
}

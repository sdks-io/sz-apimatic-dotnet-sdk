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
/// Agent runs: create, poll, list, cancel
/// </summary>
public sealed class Agent
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Agent(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel an agent run
    /// </summary>
    /// <param name="id">The run id.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AgentRun"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelAgentRunError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Stop a run that has not finished. Returns the run, unchanged if it had already ended, so cancelling is safe to retry.
    /// </remarks>
    public Task<AgentRun> CancelAgentRun(string id,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/agent/runs/{id}/cancel"),
            [new TemplateParam("id", id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<AgentRun>(),
            CancelAgentRunErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Start an agent run
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AgentRun"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateAgentRunError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the new run in <c>pending</c> state. Poll it by id until <c>status</c> reaches a terminal state.
    /// </remarks>
    public Task<AgentRun> CreateAgentRun(CreateAgentRunRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/agent/runs"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<AgentRun>(),
            CreateAgentRunErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieve an agent run
    /// </summary>
    /// <param name="id">The run id.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AgentRun"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetAgentRunError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Poll until <c>status</c> reaches a terminal state.
    /// </remarks>
    public Task<AgentRun> GetAgentRun(string id,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/agent/runs/{id}"),
            [new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AgentRun>(),
            GetAgentRunErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// List this org's agent runs
    /// </summary>
    /// <param name="limit">Page size, 1-100. Defaults to 20.</param>
    /// <param name="after">Pagination cursor: the previous page's <c>next</c>.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListAgentRunsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListAgentRunsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The organization's runs, newest first. Pass one page's <c>next</c> as the following request's <c>after</c>.
    /// </remarks>
    public Task<ListAgentRunsResponse> ListAgentRuns(long? limit,
        string? after,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/agent/runs"),
            [],
            [new Param("limit", limit), new Param("after", after)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListAgentRunsResponse>(),
            ListAgentRunsErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);
}

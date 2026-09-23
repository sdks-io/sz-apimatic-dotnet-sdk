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
/// Run history and per-request outcomes
/// </summary>
public sealed class Runs
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Runs(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// One run: status, counts and timings
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="runId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetRunResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetRunError"/> when the server returns an error response.</exception>
    public Task<GetRunResponse> GetRun(string monitorId,
        string runId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}/runs/{run_id}"),
            [new TemplateParam("monitor_id", monitorId), new TemplateParam("run_id", runId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetRunResponse>(),
            GetRunErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// One run's per-request outcomes
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="runId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListRunRequestsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListRunRequestsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// The only place a customer can tell *this query failed* from *there was genuinely nothing new*: records are a stream of positives, and absence cannot be inferred from presences.
    /// </remarks>
    public Task<ListRunRequestsResponse> ListRunRequests(string monitorId,
        string runId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}/runs/{run_id}/requests"),
            [new TemplateParam("monitor_id", monitorId), new TemplateParam("run_id", runId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListRunRequestsResponse>(),
            ListRunRequestsErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Run history, newest first
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="since">Exclusive lower bound on <c>run_id</c>.</param>
    /// <param name="before">Exclusive upper bound on <c>run_id</c>.</param>
    /// <param name="limit">Defaults to 100, at most 1,000.</param>
    /// <param name="sort"><c>desc</c> (the default, newest first) or <c>asc</c>.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListRunsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListRunsError"/> when the server returns an error response.</exception>
    public Task<ListRunsResponse> ListRuns(string monitorId,
        string? since,
        string? before,
        int? limit,
        string? sort,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}/runs"),
            [new TemplateParam("monitor_id", monitorId)],
            [new Param("since", since),
                new Param("before", before),
                new Param("limit", limit),
                new Param("sort", sort)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListRunsResponse>(),
            ListRunsErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);
}

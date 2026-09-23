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
/// The delivered records
/// </summary>
public sealed class Records
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Records(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// The flat record cursor, oldest first
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="since">Exclusive lower bound on <c>record_id</c>.</param>
    /// <param name="before">Exclusive upper bound on <c>record_id</c>.</param>
    /// <param name="limit">Defaults to 100, at most 1,000. A short page is normal: a page ends at <c>limit</c> or at the byte budget, whichever binds first.</param>
    /// <param name="includeContent">Include each record's document content. Defaults to true.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListRecordsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListRecordsError"/> when the server returns an error response.</exception>
    public Task<ListRecordsResponse> ListRecords(string monitorId,
        string? since,
        string? before,
        int? limit,
        bool? includeContent,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}/records"),
            [new TemplateParam("monitor_id", monitorId)],
            [new Param("since", since),
                new Param("before", before),
                new Param("limit", limit),
                new Param("include_content", includeContent)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListRecordsResponse>(),
            ListRecordsErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// One run's records
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="runId"></param>
    /// <param name="since">Exclusive lower bound on <c>record_id</c>.</param>
    /// <param name="before">Exclusive upper bound on <c>record_id</c>.</param>
    /// <param name="limit">Defaults to 100, at most 1,000. A short page is normal: a page ends at <c>limit</c> or at the byte budget, whichever binds first.</param>
    /// <param name="includeContent">Include each record's document content. Defaults to true.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListRunRecordsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListRunRecordsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Exists so that no consumer does arithmetic on a record id: a webhook carries a run's record range as a bound, not a dense sequence.
    /// </remarks>
    public Task<ListRunRecordsResponse> ListRunRecords(string monitorId,
        string runId,
        string? since,
        string? before,
        int? limit,
        bool? includeContent,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}/runs/{run_id}/records"),
            [new TemplateParam("monitor_id", monitorId), new TemplateParam("run_id", runId)],
            [new Param("since", since),
                new Param("before", before),
                new Param("limit", limit),
                new Param("include_content", includeContent)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListRunRecordsResponse>(),
            ListRunRecordsErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);
}

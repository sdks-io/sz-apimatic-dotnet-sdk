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
/// Monitor configuration
/// </summary>
public sealed class Monitors
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Monitors(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a monitor
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateMonitorResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateMonitorError"/> when the server returns an error response.</exception>
    public Task<CreateMonitorResponse> CreateMonitor(CreateMonitorRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateMonitorResponse>(),
            CreateMonitorErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Soft-delete a monitor
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="object"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteMonitorError"/> when the server returns an error response.</exception>
    public Task<object> DeleteMonitor(string monitorId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}"),
            [new TemplateParam("monitor_id", monitorId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<object>(),
            DeleteMonitorErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Get one monitor
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetMonitorResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetMonitorError"/> when the server returns an error response.</exception>
    public Task<GetMonitorResponse> GetMonitor(string monitorId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}"),
            [new TemplateParam("monitor_id", monitorId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetMonitorResponse>(),
            GetMonitorErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// List this org's monitors
    /// </summary>
    /// <param name="name">Matches a monitor whose name is exactly this.</param>
    /// <param name="status">One of <c>active</c>, <c>paused</c>, <c>disabled</c>. <c>deleted</c> is not a filter: a deleted monitor is invisible.</param>
    /// <param name="since">Exclusive lower bound: the <c>monitor_id</c> of a monitor to start after.</param>
    /// <param name="before">Exclusive upper bound. The list is newest first, so page forward with the <c>monitor_id</c> of the last monitor on the previous page.</param>
    /// <param name="limit">Defaults to 100, at most 1,000. A short page is normal: a page ends at <c>limit</c> or at the byte budget, whichever binds first.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListMonitorsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListMonitorsError"/> when the server returns an error response.</exception>
    public Task<ListMonitorsResponse> ListMonitors(string? name,
        string? status,
        string? since,
        string? before,
        int? limit,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors"),
            [],
            [new Param("name", name),
                new Param("status", status),
                new Param("since", since),
                new Param("before", before),
                new Param("limit", limit)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListMonitorsResponse>(),
            ListMonitorsErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Edit a monitor
    /// </summary>
    /// <param name="monitorId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateMonitorResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateMonitorError"/> when the server returns an error response.</exception>
    public Task<UpdateMonitorResponse> UpdateMonitor(string monitorId,
        UpdateMonitorRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/v1/monitors/{monitor_id}"),
            [new TemplateParam("monitor_id", monitorId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            JsonRequest.Create(body),
            JsonResponse.Create<UpdateMonitorResponse>(),
            UpdateMonitorErrorResponse.Instance,
            [_auth.ApiKeyAuth],
            requestOptions,
            ct);
}

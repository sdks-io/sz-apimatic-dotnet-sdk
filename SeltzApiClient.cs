using System.Net.Http;
using SeltzApi.Api;
using SeltzApi.Core;
using SeltzApi.Core.Logging;
using SeltzApi.Core.Models;

namespace SeltzApi;

/// <summary>
/// REST API for the Seltz platform: context retrieval (<c>/v1/search</c>), RAG answers (<c>/v1/answer</c>), monitors (<c>/v1/monitors</c>), and page fetching (<c>/v1/fetch</c>).
/// </summary>
public sealed class SeltzApiClient
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    public SeltzApiClient(HttpClient httpClient, SeltzApiClientOptions options)
    {
        _server = new Server(options.Environment, options.Server);
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(queryParameterFactory, templateParamsFactory);
        var httpStatusPolicy = new HttpStatusPolicy([]);
        var headersFactory =
            new HeadersFactory([new HeaderParam("User-Agent", "SeltzApiClient/1.9.0 CSharp"),
                    new HeaderParam("X-APIMatic-Lang", "CSharp"),
                    new HeaderParam("X-APIMatic-Package-Version", "1.9.0"),
                    new HeaderParam("X-APIMatic-Gen-Version", "4.0.0"),
                    new HeaderParam("X-APIMatic-OS", RuntimeEnvironment.Os),
                    new HeaderParam("X-APIMatic-Runtime", RuntimeEnvironment.Runtime)]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.Retry);
        var httpLogger = new HttpLogger(options.Logging, "SeltzApiClient");
        _rawClient =
            new RawClient(httpClient,
                urlFactory,
                httpStatusPolicy,
                headersFactory,
                resiliencePipelineFactory,
                httpLogger,
                options.Hooks);
        _auth = new AuthSchemes(options);
    }

    /// <summary>
    /// Agent runs: create, poll, list, cancel
    /// </summary>
    public Agent Agent => field ??= new Agent(_rawClient, _server, _auth);

    /// <summary>
    /// Answer operations
    /// </summary>
    public Answer Answer => field ??= new Answer(_rawClient, _server, _auth);

    /// <summary>
    /// Fetch operations
    /// </summary>
    public Fetch Fetch => field ??= new Fetch(_rawClient, _server, _auth);

    /// <summary>
    /// Monitor configuration
    /// </summary>
    public Monitors Monitors => field ??= new Monitors(_rawClient, _server, _auth);

    /// <summary>
    /// The delivered records
    /// </summary>
    public Records Records => field ??= new Records(_rawClient, _server, _auth);

    /// <summary>
    /// Run history and per-request outcomes
    /// </summary>
    public Runs Runs => field ??= new Runs(_rawClient, _server, _auth);

    /// <summary>
    /// Search operations
    /// </summary>
    public Search Search => field ??= new Search(_rawClient, _server, _auth);
}

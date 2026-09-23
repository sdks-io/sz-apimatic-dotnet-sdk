using System.Collections.Generic;
using SeltzApi.Core.Configuration;
using SeltzApi.Core.Hooks;
using SeltzApi.Servers;

namespace SeltzApi;

public class SeltzApiClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public LoggingOptions Logging { get; set; } = new();
    public ServerOptions Server { get; set; } = new();
    public IReadOnlyList<SdkHook> Hooks { get; set; } = [];
    /// <summary>
    /// Seltz API key. Create one in the <see href="https://console.seltz.ai/api-keys">Seltz Console</see> under <b>Settings → API Keys</b>.
    /// </summary>
    public string? ApiKeyAuth { get; set; }
}

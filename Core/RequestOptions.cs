using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SeltzApi.Core.Hooks;

namespace SeltzApi.Core;

public sealed record RequestOptions
{
    public LogLevel? LogLevel { get; init; }

    public IReadOnlyList<SdkHook>? Hooks { get; init; }
}

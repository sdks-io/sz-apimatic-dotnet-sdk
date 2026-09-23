
# Monitor Status

A monitor's lifecycle state.

`active` is scheduled and running. `paused` runs nothing and keeps its
records and its record of what it has already delivered. Only those two can
be set through the API; `disabled` and `deleted` are set by Seltz.

## Enumeration

`MonitorStatus`

## Fields

| Name |
|  --- |
| `Active` |
| `Paused` |
| `Disabled` |
| `Deleted` |

## Example

```csharp
using SeltzApi.Standard.Models;

MonitorStatus monitorStatus = MonitorStatus.Active;
```


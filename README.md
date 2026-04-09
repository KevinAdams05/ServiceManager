# Service Manager

A Windows desktop application for monitoring and controlling Windows services and IIS web servers across multiple remote machines.

## Features

- **Service Management** - Start, stop, and monitor Windows services on remote servers
- **IIS Management** - Reset, start, and stop IIS on remote web servers
- **Memory Monitoring** - View memory usage (MB) for each running service
- **Auto Refresh** - Configurable automatic refresh interval (default: 5 minutes)
- **Dockable Panels** - Rearrange Services, Web Servers, and Status Log panels with drag-and-drop docking
- **72 Themes** - Choose from 72 community palette themes (Office, Visual Studio, Adobe CC, and more)
- **Environment Filter** - Filter servers by environment name
- **Production Warnings** - Configurable warnings when performing actions on production servers
- **Persistent Settings** - Default sort column, theme, and refresh interval saved to config

## Requirements

- Windows 10/11
- .NET 10 Runtime
- Administrator privileges (for remote service control)
- IIS installed locally (for remote IISReset)

## Getting Started

1. Build and run the application
2. Click **Edit Server List** to add your servers
3. For each server, specify:
   - **Environment** - e.g., DEV, QA, PROD
   - **Server Name** - the machine hostname
   - **Server Type** - Service or WebServer
   - **Service Name** - the Windows service name (for Service type)
4. Click **Refresh** to check service statuses

## Configuration

Settings are stored in `ServiceManager.dll.config`:

| Setting | Default | Description |
|---------|---------|-------------|
| `DefaultSortColumn` | `0` | Column index for default grid sorting |
| `WarnOnProduction` | `true` | Show confirmation dialog for production actions |
| `ProductionEnvironmentTerms` | `prod;production;prd` | Semicolon-separated terms that identify production environments |
| `Theme` | `LightGray` | Default palette theme name |
| `AutoRefreshMinutes` | `5` | Auto-refresh interval in minutes |

## Themes

The application includes 72 palette themes from the [Krypton-Suite/Theme-Palettes](https://github.com/Krypton-Suite/Theme-Palettes) community repository. Click the **Theme** button to browse and apply themes. Right-click a theme or use "Set Current as Default" to persist your choice.

## Libraries

- [Krypton Suite Standard Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) v100.26.1.19 - UI controls and theming (BSD-3-Clause)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) v13.0.3 - JSON serialization (MIT)
- [System.ServiceProcess.ServiceController](https://www.nuget.org/packages/System.ServiceProcess.ServiceController) v9.0.4 - Windows service control
- [System.Management](https://www.nuget.org/packages/System.Management) v9.0.4 - WMI queries for memory monitoring

## Author

Kevin Adams - [GitHub](https://github.com/KevinAdams05)

## License

See repository for license details.

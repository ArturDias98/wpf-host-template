using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace HostTemplate;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = new HostBuilder()
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
       await _host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}

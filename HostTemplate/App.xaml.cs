using HostTemplate.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace HostTemplate;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = new HostBuilder()
            .ConfigureAppConfiguration((context, configureBuilder) =>
            {
                configureBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                configureBuilder.AddJsonFile("appsettings.json", false);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<AccountSettings>(context.Configuration.GetSection(AccountSettings.Section));
                services.AddServices();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var window = _host.Services.GetService<MainWindow>();
        window?.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}

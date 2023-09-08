# WPF Generic Host project for .NET
This project follows the implementation available in [WPF and .NET Generic Host](https://laurentkempe.com/2019/09/03/WPF-and-dotnet-Generic-Host-with-dotnet-Core-3-0/).  
With Generic Host Model you can configure an WPF application as a ASP.NET application.
## Configure App
Firs of all you need to override the default App.xaml configuration.
You must remove StartupUri.  
```xaml
<Application x:Class="HostTemplate.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Application.Resources>

    </Application.Resources>
</Application>
``` 
Next you need to configure the Generic Host interface in your App.xaml.cs  
```cs
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
``` 
To make Host configuration more clean we move the Dependency Injection to another Class.    
```cs
public static IServiceCollection AddServices(this IServiceCollection services)
{
    return services
           .AddUI()
           .AddWorkers();
}

 private static IServiceCollection AddUI(this IServiceCollection services)
 {
     return services
         .AddTransient<MainWindow>();
 }

 private static IServiceCollection AddWorkers(this IServiceCollection services)
{
    return services
        .AddHostedService<SampleWorker>();
}
```
You can consume configuration instances.  
```cs
private readonly AccountSettings _accountSettings;
public MainWindow(IOptions<AccountSettings> options)
{
    _accountSettings = options.Value;

    InitializeComponent();
}
```
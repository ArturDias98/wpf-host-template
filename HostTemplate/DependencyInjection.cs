using HostTemplate.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace HostTemplate;

internal static class DependencyInjection
{
    /// <summary>
    /// Add project dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
               .AddUI()
               .AddWorkers();
    }

    /// <summary>
    /// Add User Interface dependencies.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddUI(this IServiceCollection services)
    {
        return services
            .AddTransient<MainWindow>();
    }

    /// <summary>
    /// Add Hosted Services.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddWorkers(this IServiceCollection services)
    {
        return services
            .AddHostedService<SampleWorker>();
    }
}

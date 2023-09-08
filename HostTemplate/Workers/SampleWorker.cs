using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace HostTemplate.Workers;

internal class SampleWorker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}

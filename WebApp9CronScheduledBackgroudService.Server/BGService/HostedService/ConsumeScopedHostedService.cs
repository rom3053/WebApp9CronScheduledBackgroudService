using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp9CronScheduledBackgroudService.Server.BGService.HostedService
{
    public class ConsumeScopedHostedService : BackgroundService
    {
        private readonly IServiceProvider _service;
        private SchedulerService scheduler;
        private TimeSpan DelayTime { get; set; } = new TimeSpan(0,0,15);
        public ConsumeScopedHostedService(IServiceProvider service, SchedulerService schedulerService)
        {
            _service = service;
            scheduler = schedulerService;
            scheduler.IntervalInMinutes(DateTime.Now.Hour, DateTime.Now.AddMinutes(1).Minute, 1, () => DoWorkStatus());
        }
        public ConsumeScopedHostedService(IServiceProvider service, int delayTimeSeconds)
        {
            _service = service;
            DelayTime = new TimeSpan(0, 0, delayTimeSeconds);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DoWork();
                Console.WriteLine($"Campaign background service Hearthbeat at {DelayTime:%m\\:ss} {DateTime.Now} ");
                await Task.Delay(DelayTime, stoppingToken);
            }
        }

        private async Task DoWork()
        {
            using (var scope = _service.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IBackgroundCampaignSender>();
                await scopedProcessingService.DoWork();
                Console.WriteLine($"{DateTime.Now} Processing.BackgroundExecution - Execution loop Worker");
            }
        }
        private async Task DoWorkStatus()
        {
            using (var scope = _service.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IBackgroundCampaignSender>();
                await scopedProcessingService.DoWorkStatus();
                Console.WriteLine($"{DateTime.Now} Processing.BackgroundExecution - Execution loop ServerWatchdog");
            }
        }
    }
}

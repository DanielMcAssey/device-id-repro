using DeviceIdBugRepro.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceIdBugRepro
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DebugService debugService;

        public Worker(ILogger<Worker> logger, DebugService debugService)
        {
            _logger = logger;
            this.debugService = debugService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("Device ID is: {device}", debugService.DeviceId);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

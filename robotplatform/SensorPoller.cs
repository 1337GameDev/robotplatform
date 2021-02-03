using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace robotplatform
{
    public class SensorPoller : BackgroundService
    {
        private readonly ILogger<SensorPoller> _logger;

        public SensorPoller(ILogger<SensorPoller> logger)
        {
            _logger = logger;
            Pi.Init<BootstrapWiringPi>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("Pi info: {info}", Pi.Info.ToString());
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

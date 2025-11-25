using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using waPLD_8.Models.Shared;

namespace waPLD_8.Services
{
    public class ChartDataService : IHostedService
    {
        private readonly IHubContext<ChartHub> _hubContext;
        private Timer _timer;

        public ChartDataService(IHubContext<ChartHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendData, null, 0, 2000); // Enviar datos cada 2 segundos
            return Task.CompletedTask;
        }

        private void SendData(object state)
        {
            var random = new Random();
            var data = new List<double>
        {
            random.Next(0, 100),
            random.Next(0, 100),
            random.Next(0, 100)
        };

            _hubContext.Clients.All.SendAsync("ReceiveChartData", data);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace waPLD.Models.Shared
{
    public class ChartHub:Hub
    {
        // Método para enviar datos al cliente
        //public async Task SendChartData(List<double> data)
        //{
        //    await Clients.All.SendAsync("ReceiveChartData", data);
        //}
        public async Task SendResponseTime(string url, long responseTimeMs, int statusCode)
        {
            await Clients.All.SendAsync("ReceiveResponseTime", url, responseTimeMs, statusCode);
        }
    }
}
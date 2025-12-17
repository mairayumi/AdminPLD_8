using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using waPLD.Models.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace waPLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hubContext;
        private readonly HttpClient _httpClient;

        public ChartController(IHubContext<ChartHub> hubContext)
        {
            _hubContext = hubContext;
            _httpClient = new HttpClient();
        }

        [HttpGet("checkOut")]
        public async Task<IActionResult> GetResponseTime(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest("URL is required.");
            }

            var stopwatch = Stopwatch.StartNew();
            try
            {
                var response = await _httpClient.GetAsync(url);
                stopwatch.Stop();
                var responseTime = stopwatch.ElapsedMilliseconds;

                // Enviar el tiempo de respuesta a los clientes conectados
                await _hubContext.Clients.All.SendAsync("ReceiveResponseTime", url, responseTime, (int)response.StatusCode);

                return Ok(new
                {
                    Url = url,
                    ResponseTimeMs = responseTime,
                    StatusCode = response.StatusCode
                });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
using DashboardApi.Dto;
using DashboardApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace DashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IHubContext<HubMessageService> _hubContext;
        private readonly ILogger<NotifyController> _logger;

        public NotifyController(IHubContext<HubMessageService> hubContext, ILogger<NotifyController> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        [HttpPost("message")]
        public async Task<IActionResult> RecibirAlerta([FromBody] MessageModel mensaje)
        {
            //string message = data.GetValue("message").ToString();

            MessageResponse model = new MessageResponse();
            model.message = mensaje.mensaje;
            await _hubContext.Clients.All.SendAsync("notify", model);

            return Ok();
        }

        [HttpGet("ejemplo")]
        public async Task<IActionResult> Respuesta()
        {
            MessageResponse model = new MessageResponse();
            model.message = "Se ha registrado un nuevo ticket";
            await _hubContext.Clients.All.SendAsync("notify", model);

            return Ok(model);
        }
    }
}

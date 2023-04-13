using DashboardApi.Services;
using DashboardApi.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly ILogger<TicketStatusController> _logger;
        private readonly ITicketsStatusService _service;

        public TicketStatusController(ILogger<TicketStatusController> logger, ITicketsStatusService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("TicketsNotAcepted")]
        public async Task<IActionResult> GetStatusTicketsNotAcepted()
        {
            ModelRequest res = new ModelRequest();
            var result = await _service.GetTicketsStatusNotAcepted();
            
            if (result == null) 
            {
                res.message = "Error";
                res.data = "Error al consultar tickets";
                return BadRequest(res);
            }

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("TicketsUnManaged")]
        public async Task<IActionResult> GetStatusTicketsNews()
        {
            ModelRequest res = new ModelRequest();
            var result = await _service.GetTicketsStatusUnManaged();

            if(result == null)
            {
                res.message = "Error";
                res.data = "Error al consultar tickets";
                return BadRequest(res);
            }

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("notResolved")]
        public async Task<IActionResult> GetStatusTicketsNotResolved()
        {
            ModelRequest res = new ModelRequest();
            var result = await _service.GetTicketsStatusNotResolved();
            if(result == null)
            {
                res.message = "Error";
                res.data = "Error al consultar tickets";
                return BadRequest(res);
            }

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("noGestionados")]
        public async Task<IActionResult> GetStatusNotManaged()
        {
            ModelRequest res = new ModelRequest();
            var result = await _service.GetTicketsStatusSinGestionar();
            if (result == null)
            {
                res.message = "Error";
                res.data = "Error al consultar tickets";
                return BadRequest(res);
            }

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }
    }
}

using DashboardApi.Services;
using DashboardApi.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly ILogger<ChartController> _logger;
        private readonly IChartServices _services;

        public ChartController(ILogger<ChartController> logger, IChartServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.ObtenerClientes();

            if (result == null)
            {
                res.message = "Error";
                res.data = "Ocurrio un error al mostrar los clientes";
                return BadRequest(res);
            }

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("ticketsNuevos")]
        public async Task<IActionResult> GetTicketsResolved()
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.TicketsNuevos();

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("ticketsNotResolved")]
        public async Task<IActionResult> GetTicketsNotResolved()
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.TicketsNotResolved();

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("ticketsUnManaged")]
        public async Task<IActionResult> GetTicketsUnManaged()
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.TicketsUnManaged();

            res.message = "Ok";
            res.data = result;

            return Ok(res);                    
        }

        [HttpGet("ticketsNotAcepted")]
        public async Task<IActionResult> GetTicketsNotAcepted()
        {
            ModelRequest res = new ModelRequest();
            var result = await _services.TicketsNotAcepted();

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }
    }
}

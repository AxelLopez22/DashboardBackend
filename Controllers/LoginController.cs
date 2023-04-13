using DashboardApi.Dto;
using DashboardApi.Services;
using DashboardApi.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginServices loginServices, ILogger<LoginController> logger)
        {
            _loginServices = loginServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            ModelRequest res = new ModelRequest();
            var result = await _loginServices.Login(model);

            if(result == null)
            {
                res.message = "Error";
                res.data = "Credenciales invalidas";

                return BadRequest(res);
            }

            res.message = "Ok";
            res.data = result;

            return Ok(res);
        }
    }
}

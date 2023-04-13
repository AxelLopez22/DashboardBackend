using DashboardApi.Context;
using DashboardApi.Dto;
using DashboardApi.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DashboardApi.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly pcgroups_mantisContext _context;
        private readonly IConfiguration _config;

        public LoginServices(pcgroups_mantisContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<ModelResponseAuth> Login(LoginDTO model)
        {
            try
            {
                string passwordHash = HashPassword.Encrypt(model.Password);
                var user = await _context.MantisUserTables.Where(x => x.Username == model.UserName && x.Password == passwordHash)
                    .FirstOrDefaultAsync();

                if(user != null)
                {
                    return await ConstruirToken(model.UserName);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private async Task<ModelResponseAuth> ConstruirToken(string UserName)
        {
            var Claims = new List<Claim>()
            {
                new Claim("Usuario", UserName)
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["LlaveJwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var Expiracion = DateTime.UtcNow.AddDays(1);
            var securityToken = new JwtSecurityToken(issuer: "localhost", audience: "localhost", claims: Claims,
                expires: Expiracion, signingCredentials: creds);

            return new ModelResponseAuth()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Fecha = Expiracion
            };
        }
    }

    public interface ILoginServices
    {
        Task<ModelResponseAuth> Login(LoginDTO model);
    }
}

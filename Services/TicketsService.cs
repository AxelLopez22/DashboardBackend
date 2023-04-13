using DashboardApi.Context;
using DashboardApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Services
{
    public class TicketsService : ITicketsStatusService
    {
        private readonly pcgroups_mantisContext _context;

        public TicketsService(pcgroups_mantisContext context)
        {
            _context = context;
        }

        public async Task<List<TicketsModal>> GetTicketsStatusUnManaged()
        {
            try
            {
                var result = await _context.ViewUnmanageds.Select(s => new TicketsModal()
                {
                    IdBug = (int)s.C,
                    Cliente = s.Username,
                    Descripcion = s.Summary,
                    Fecha = ObtenerFecha(s.DateSubmitted)
                }).ToListAsync();

                return result.OrderByDescending(x => x.Fecha).ToList();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<TicketsModal>> GetTicketsStatusNotResolved()
        {
            try
            {
                var result = await _context.ViewNoResueltos.Select(s => new TicketsModal()
                {
                    IdBug = (int)s.C,
                    Cliente = s.Username,
                    Descripcion = s.Summary,
                    Fecha = ObtenerFecha(s.DateSubmitted)
                }).ToListAsync();

                return result.OrderByDescending(x => x.Fecha).ToList();
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<List<TicketsModal>> GetTicketsStatusNotAcepted()
        {
            try
            {
                var result = await _context.ViewNotAcepteds.Select(s => new TicketsModal()
                {
                    IdBug = (int)s.C,
                    Cliente = s.Username,
                    Descripcion = s.Summary,
                    Fecha = ObtenerFecha(s.DateSubmitted)
                }).ToListAsync();

                return result.OrderByDescending(x => x.Fecha).ToList();
            } catch
            {
                return null;
            }
        }

        public async Task<List<TicketsModal>> GetTicketsStatusSinGestionar()
        {
            try
            {
                var result = await _context.ViewNoGestionados.Select(s => new TicketsModal()
                {
                    IdBug = (int)s.C,
                    Cliente = s.Username,
                    Descripcion = s.Summary,
                    Fecha = ObtenerFecha(s.DateSubmitted)
                }).ToListAsync();

                return result.OrderByDescending(x => x.Fecha).ToList();
            } catch
            {
                return null;
            }
        }

        private static DateTime ObtenerFecha(uint fecha)
        {
            DateTimeOffset fechaConvert = DateTimeOffset.FromUnixTimeSeconds(fecha);
            return fechaConvert.DateTime.AddHours(-6);
        }
    }

    public interface ITicketsStatusService
    {
        Task<List<TicketsModal>> GetTicketsStatusNotResolved();
        Task<List<TicketsModal>> GetTicketsStatusUnManaged();
        Task<List<TicketsModal>> GetTicketsStatusNotAcepted();
        Task<List<TicketsModal>> GetTicketsStatusSinGestionar();
    }
}

//{ "userName": "Luis Vargas", "password": "PCG2@23LV" }

using DashboardApi.Context;
using DashboardApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Services
{
    public class ChartServices : IChartServices
    {
        private readonly pcgroups_mantisContext _context;

        public ChartServices(pcgroups_mantisContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteDTO>> ObtenerClientes()
        {
            try
            {
                var result = await (from bug in _context.MantisBugTables
                                    join history in _context.MantisBugHistoryTables
                                    on bug.Id equals history.BugId
                                    join users in _context.MantisUserTables
                                    on history.UserId equals users.Id
                                    where users.AccessLevel <= 25 && users.Enabled == 1 && 
                                    (bug.Status == 30 || bug.Status == 40 || bug.Status == 50 || bug.Status == 20 || bug.Status == 10)
                                    group history by users.Id into g                                  
                                    select new ClienteDTO()
                                    {
                                        IdUser = g.Select(x => x.UserId).FirstOrDefault(),
                                        NombreClientes = "",
                                        cantidadTickets = g.Select(x => x.BugId).Distinct().Count()
                                    }
                         ).Take(20).OrderByDescending(x => x.cantidadTickets).ToListAsync();

                var result2 = await ObtenerNombres(result);

                return result2;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> TicketsNotResolved()
        {
            var result = await _context.MantisBugTables
                .Where(x => x.Status == 50 || x.Status == 40 || x.Status == 30).CountAsync();

            return result;
        }

        public async Task<int> TicketsNuevos()
        {
            var result = await _context.MantisBugTables.Where(x => x.Status == 10).CountAsync();
            return result;
        }

        public async Task<int> TicketsUnManaged()
        {
            var result = await _context.MantisBugTables.Where(b => !_context.MantisBugnoteTables.Any(n => n.BugId == b.Id) 
                && b.Status != 90 && b.Status != 80)
                .ToListAsync();
            int cantidad = result.Count();
            return cantidad;
        }

        public async Task<int> TicketsNotAcepted()
        {
            var result = await _context.MantisBugTables.Where(x => x.Status == 20).CountAsync();
            return result;
        }

        //Private Methods
        private async Task<string> GetName(uint id)
        {
            var result = await _context.MantisUserTables.Where(x => x.AccessLevel <= 25 && x.Enabled == 1 && x.Id == id)
                            .Select(x => x.Username).FirstAsync();
            return result;
        }

        private async Task<List<ClienteDTO>> ObtenerNombres(List<ClienteDTO> model)
        {
            List<ClienteDTO> newlist = new List<ClienteDTO>();
            foreach (var clienteDTO in model)
            {

                ClienteDTO nuevoClienteDTO = new ClienteDTO
                {
                    IdUser = clienteDTO.IdUser,
                    cantidadTickets = clienteDTO.cantidadTickets,

                    NombreClientes = await GetName(clienteDTO.IdUser)
                };

                newlist.Add(nuevoClienteDTO);
            };
            return newlist;
        }
    }

    public interface IChartServices
    {
        Task<List<ClienteDTO>> ObtenerClientes();
        Task<int> TicketsNuevos();
        Task<int> TicketsNotResolved();
        Task<int> TicketsUnManaged();
        Task<int> TicketsNotAcepted();
    }
}

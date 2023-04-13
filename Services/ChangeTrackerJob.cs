
using DashboardApi.Context;
using DashboardApi.Dto;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Xml.Linq;

namespace DashboardApi.Services
{
    public class ChangeTrackerJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ChangeTrackerJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IScopedProcessingService scopedProcessing = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

                await scopedProcessing.DoWorkAsync(stoppingToken);
            }
        }
    }

    public interface IScopedProcessingService
    {
        Task DoWorkAsync(CancellationToken stoppingToken);
    }

    public sealed class DefaultScopedProcessingService : IScopedProcessingService
    {
        private readonly IHubContext<HubMessageService> _messageService;
        private readonly pcgroups_mantisContext _context;
        private readonly ILogger<DefaultScopedProcessingService> _logger;
        private int _previousRowCount;

        public DefaultScopedProcessingService(
            ILogger<DefaultScopedProcessingService> logger,
            IHubContext<HubMessageService> messageService,
            pcgroups_mantisContext context)
        {
            _logger = logger;
            _messageService = messageService;
            _context = context;
        }
            
        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            int previousRowCount = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                var ticketsNotResolved = await _context.MantisBugTables.Where(x => x.Status == 50 || x.Status == 40 || x.Status == 30).CountAsync();
                var ticketsnuevos = await _context.MantisBugTables.Where(x => x.Status == 10).CountAsync();
                var ticketsUnManaged = await _context.MantisBugTables.Where(b => !_context.MantisBugnoteTables.Any(n => n.BugId == b.Id)
                                        && b.Status != 90 && b.Status != 80).CountAsync();
                var ticketsNotAcepted = await _context.MantisBugTables.Where(x => x.Status == 20).CountAsync();

                if(previousRowCount < ticketsnuevos)
                {
                    _logger.LogInformation("Se inserto un nuevo registro");
                    var nombreUser = await NameClient();
                    _logger.LogInformation(nombreUser.ToString());
                    await _messageService.Clients.All.SendAsync("notify", nombreUser);
                }

                if(previousRowCount > ticketsnuevos)
                {
                    _logger.LogInformation("Tabla actualizada");
                    var nombreUser = await NameClient();
                    await _messageService.Clients.All.SendAsync("updateTable", nombreUser);
                }

                await _messageService.Clients.All.SendAsync("TicketsNuevos", ticketsnuevos);
                await _messageService.Clients.All.SendAsync("TicketsNotResolved", ticketsNotResolved);
                await _messageService.Clients.All.SendAsync("TicketsUnManaged", ticketsUnManaged);
                await _messageService.Clients.All.SendAsync("TicketsNotAcepted", ticketsNotAcepted);

                previousRowCount = ticketsnuevos;

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }   
        }

        private async Task<List<MessageResponse>> NameClient()
        {
            DateTime now = DateTime.Now;
            DateTime fechaActualInicio = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            DateTime fechaActualFinal = fechaActualInicio.AddDays(1);

            var bugs = await _context.ViewUnmanageds.ToListAsync();

            var bugsToday = bugs.Where(x => ObtenerFecha(x.DateSubmitted) > fechaActualInicio
                                    && ObtenerFecha(x.DateSubmitted) < fechaActualFinal)
                                    .Select(x => new MessageResponse()
                                    {
                                        fecha = ObtenerFecha(x.DateSubmitted),
                                        message = x.Username
                                    }).ToList();

            return bugsToday;
        }

        private static DateTime ObtenerFecha(uint fecha)
        {
            DateTimeOffset fechaConvert = DateTimeOffset.FromUnixTimeSeconds(fecha);
            return fechaConvert.DateTime.AddHours(-6);
        }
    }
}

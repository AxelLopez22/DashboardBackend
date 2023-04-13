using DashboardApi.Dto;
using Microsoft.AspNetCore.SignalR;

namespace DashboardApi.Services
{
    public class HubMessageService : Hub
    {
        public async Task SendMessage(List<MessageResponse> model)
        {
            await Clients.All.SendAsync("notify", model);
        }

        public async Task UpdateTable(List<MessageResponse> model)
        {
            await Clients.All.SendAsync("updateTable", model);
        }

        public async Task CountTicketsUnManaged(int cant)
        {
            await Clients.All.SendAsync("TicketsUnManaged", cant);
        }

        public async Task CountTicketsResolved(int cant)
        {
            await Clients.All.SendAsync("TicketsNuevos", cant);
        }

        public async Task CountTicketsNotResolved(int cant)
        {
            await Clients.All.SendAsync("TicketsNotResolved", cant);
        }

        public async Task CountTicketsNotAcepted(int cant)
        {
            await Clients.All.SendAsync("TicketsNotAcepted", cant);
        }
    }
}

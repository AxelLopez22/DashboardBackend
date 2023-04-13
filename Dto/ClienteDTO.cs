namespace DashboardApi.Dto
{
    public class ClienteDTO
    {
        public uint IdUser { get; set; }
        public string NombreClientes { get; set; }
        public int cantidadTickets { get; set; }
    }

    public class NombreClientesDTO
    {
        public string NombreClientes { get; set; }
    }

    public class TicketsModal
    {
        public int IdBug { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set;}
    }
}

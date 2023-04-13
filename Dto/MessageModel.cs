namespace DashboardApi.Dto
{
    public class MessageModel
    {
        public string mensaje { get; set; }
    }

    public class MessageResponse
    {
        public DateTime fecha { get; set; } = DateTime.Now;
        public string message { get; set; }
    }
}

namespace DashboardApi.Utilidades
{
    public class ModelRequest
    {
        public string message { get; set; }
        public object data { get; set; }
    }

    public class ModelResponseAuth
    {
        public string Token { get; set; }
        public DateTime Fecha { get; set; }
    }
}

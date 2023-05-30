namespace webConsulta.Models
{
    public class SolicitarServicio
    {
        public string auth_wsDatosSocio { get; set; } = null!;
        public string typeAuthAcceso { get; set; } = "authorization";
        public string contentType { get; set; } = "application/json";
        public object objSolicitud { get; set; } = new object();
        public Dictionary<string, object> dcyHeadersAdicionales { get; set; } = new Dictionary<string, object>();
        public string urlServicio { get; set; } = string.Empty;
        public string idTransaccion { get; set; } = string.Empty;
        public string tipoMetodo { get; set; } = "GET";
    }
}

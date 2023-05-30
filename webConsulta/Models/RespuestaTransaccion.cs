namespace webConsulta.Models
{
    public class RespuestaTransaccion
    {
        public object obj_cuerpo { get; set; } = new object();
        public string str_res_codigo { get; set; } = string.Empty;
        public string str_mensaje { get; set; } = string.Empty;

        public Dictionary<string, object> dcc_variables { get;} = new Dictionary<string, object>();
    }
}

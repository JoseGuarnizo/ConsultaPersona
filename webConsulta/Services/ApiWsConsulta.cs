using webConsulta.Models;

namespace webConsulta.Services
{
    public class ApiWsConsulta
    {
        public RespuestaTransaccion getDatosSocio(ReqDatoConsulta reqDatoConsulta)
        {
            var respuesta = new RespuestaTransaccion();
            Configuration config = new Configuration();
            HttService httService = new HttService();

            try
            {
                config.typeAuthWsConsulta = "authorization";
                config.auth_wsConsulta = "Auth-wsDatosSocio123";
                config.url_consulta = "http://localhost:7186/api/wsDatosSocio/";

                SolicitarServicio solicitar = new SolicitarServicio();
                solicitar.tipoMetodo = "GET";
                solicitar.typeAuthAcceso = config.typeAuthWsConsulta;
                solicitar.auth_wsDatosSocio = config.auth_wsConsulta;
                solicitar.urlServicio = config.url_consulta + "GetDatosSocio";
                solicitar.objSolicitud = reqDatoConsulta;
                solicitar.dcyHeadersAdicionales = new();

                string str_res_servicio = httService.solicitar_servicio(solicitar).Result;

                respuesta.obj_cuerpo = str_res_servicio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
    }
}

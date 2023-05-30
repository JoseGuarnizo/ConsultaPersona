using System.Text;
using System.Text.Json;
using webConsulta.Models;

namespace webConsulta.Services
{
    public class HttService
    {
        public object solicitar_servicio_async(SolicitarServicio solicitarServicio)
        {
            var respuesta = new object { };

            try
            {
                var client = new HttpClient();
                var request = createRequest(solicitarServicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        private HttpRequestMessage createRequest(SolicitarServicio solicitarServicio)
        {
            string str_solicitud = JsonSerializer.Serialize(solicitarServicio.objSolicitud);
            var request = new HttpRequestMessage();
            if (solicitarServicio.contentType == "application/x-www-form-urlencoded")
            {
                var parametros = JsonSerializer.Deserialize<Dictionary<string, string>>(str_solicitud); 
                request.Content = new FormUrlEncodedContent(parametros);
            }
            else
            {
                request.Content = new StringContent(str_solicitud, Encoding.UTF8, solicitarServicio.contentType);
            }

            request.Method = new HttpMethod(solicitarServicio.tipoMetodo);
            request.RequestUri = new Uri(solicitarServicio.urlServicio, System.UriKind.RelativeOrAbsolute);
            request.Content.Headers.Add("No-Paging", "true");
            return request;
        }

        public async Task<string> solicitar_servicio(SolicitarServicio solicitarServicio)
        {
            var peticion = solicitarServicio.objSolicitud;

            try
            {
                var client = new HttpClient();
                var request = createRequest(solicitarServicio);

                client.Timeout = TimeSpan.FromMinutes(10);
                var response = client.SendAsync(request).Result;

                if (Convert.ToInt32(response.StatusCode) == 200)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ArgumentException(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

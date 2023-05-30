using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using webConsulta.Models;
using webConsulta.Services;

namespace webConsulta.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string str_nombres { get; set; } = string.Empty;
        public string str_apellidos { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostProcessText(string textInput)
        {
            ApiWsConsulta apiWsConsulta = new ApiWsConsulta();
            ReqDatoConsulta reqDatoConsulta = new ReqDatoConsulta();
            var resTran = new RespuestaTransaccion();
            var respuesta = new ResDatoConsulta();

            try
            {
                reqDatoConsulta.str_cedula = textInput;

                resTran = apiWsConsulta.getDatosSocio(reqDatoConsulta);
                respuesta = JsonSerializer.Deserialize<ResDatoConsulta>((string)resTran.obj_cuerpo);

                str_nombres = respuesta!.str_nombres;
                str_apellidos = respuesta.str_apellidos;

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            ViewData["ProcessedText"] = textInput.ToUpper();
            return Page();
        }



    }
}
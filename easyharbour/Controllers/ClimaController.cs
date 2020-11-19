using easyharbour.Common;
using easyharbour.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;


namespace easyharbour.Api.Controllers
{

    [ApiController]
    public class ClimaController : BaseController
    {

        private readonly ClimaServico _climaServico;

        public ClimaController(ClimaServico climaServico)
        {
            _climaServico = climaServico;
        }

        /// <summary>
        /// Busca dados do clima para as proximas 12h.
        /// </summary>
        /// <param name="file0"></param>
        /// <returns>Lista do horas contendo dados do clima.</returns>
        [HttpPost]
        [Route("v1/clima/clima-doze-horas")]
        [SwaggerOperation(OperationId = "3BC9F9FA-946F-49E7-936A-0DCBC3D4EADB")]
        public async Task<IActionResult> UploadFichaComposicao()
        {
            try
            {
                var retorno  = await _climaServico.ObterClima();
                return Ok(retorno);
            }
            catch (RegraDeNegocioException e)
            {
            
                return BadRequest(new ResultadoOperacao(false, MensagensSistema.Erro500RegraNegocio + e.Message));
            }
            catch (Exception)
            {
                return BadRequest(new ResultadoOperacao(false, MensagensSistema.Erro500));
            }
        }
    }
}
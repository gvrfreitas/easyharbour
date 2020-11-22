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
    public class ImportacaoController : BaseController
    {

        private readonly ImportacaoServico  _importacaoServico;

        public ImportacaoController(ImportacaoServico importacaoServico)
        {
            _importacaoServico = importacaoServico;
        }

        /// <summary>
        /// Realiza a improtação das atracações programadas.
        /// </summary>
        /// <param name="file0">Arquivo CSV.</param>
        /// <returns>Mensagem de sucesso ou fracasso da operação.</returns>
        [HttpPost]
        [Route("v1/importacao/atracacoes-programadas")]
        [SwaggerOperation(OperationId = "53b636ca-9bc9-4382-911a-d0e7514575fc")]
        public async Task<IActionResult> Uploadatracacoes([FromForm] IFormFile file0)
        {
            try
            {
                await _importacaoServico.ObterDadosAtracacao(file0);
                return Ok(MensagensSistema.OperacaoOk);
            }
            catch (RegraDeNegocioException e)
            {
            
                return BadRequest(new ResultadoOperacao(false, MensagensSistema.Erro500RegraNegocio + e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoOperacao(false, MensagensSistema.Erro500));
            }
        }
    }
}
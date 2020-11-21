using easyharbour.Common;
using easyharbour.Servico;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyharbour.Api.Controllers
{
    [ApiController]
    public class AtracacaoController : BaseController
    {
        private readonly AtracacaoServico _atracacaoServico;

        public AtracacaoController(AtracacaoServico atracacaoServico)
        {
            _atracacaoServico = atracacaoServico;
        }


        /// <summary>
        /// Realiza a importação das atracações programadas.
        /// </summary>
        /// <param name="file0">Arquivo CSV.</param>
        /// <returns>Mensagem de sucesso ou fracasso da operação.</returns>
        [HttpGet]
        [Route("v1/atracacao")]
        [SwaggerOperation(OperationId = "1D3DC722-F6DF-4E98-A449-E4EB2EAC80FF")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var retorno = await _atracacaoServico.Obter();
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

        /// <summary>
        /// Realiza a importação dos navios fundiados.
        /// </summary>
        /// <param name="file0">Arquivo CSV.</param>
        /// <returns>Mensagem de sucesso ou fracasso da operação.</returns>
        [HttpGet]
        [Route("v1/atracacao/navios-fundiados")]
        [SwaggerOperation(OperationId = "99C5B5EE-5ABA-4EE8-B0AA-3588754FA603")]
        public async Task<IActionResult> ObterNaviosFundiados()
        {
            try
            {
                var retorno = await _atracacaoServico.ObterNaviosFundiados();
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

        /// <summary>
        /// Realiza a improtação dos navios em atracacao.
        /// </summary>
        /// <param name="file0">Arquivo CSV.</param>
        /// <returns>Mensagem de sucesso ou fracasso da operação.</returns>
        [HttpGet]
        [Route("v1/atracacao/navios-em-atracacao")]
        [SwaggerOperation(OperationId = "9EC08313-55CA-4842-B53B-C4BB2A4001E3")]
        public async Task<IActionResult> ObterNaviosEmOperacao()
        {
            try
            {
                var retorno = await _atracacaoServico.ObterNaviosEmOperacao();
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

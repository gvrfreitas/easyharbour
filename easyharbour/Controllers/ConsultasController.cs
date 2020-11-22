using System;
using System.Threading.Tasks;
using easyharbour.Common;
using easyharbour.Servico;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace easyharbour.Api.Controllers
{
   
    [ApiController]
    public class ConsultasController : BaseController
    {
        private readonly ConsultasServico _consultasServico;

        public ConsultasController(ConsultasServico consultasServico)
        {
            _consultasServico = consultasServico;
        }


        /// <summary>
        /// Obtém dados para a lineup programada.
        /// </summary>
        /// <returns>Lista de viaens para o lineup.</returns>
        [HttpGet]
        [Route("v1/consultas/fundeados")]
        [SwaggerOperation(OperationId = "B35130BF-7952-4045-ADEE-4C250292102E")]
        public async Task<IActionResult> ObterFundeados()
        {
            try
            {
                var retorno = await _consultasServico.ObterFundeados();
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
        /// Obtém dados para a lineup otimizada.
        /// </summary>
        /// <returns>Lista de viaens para o lineup.</returns>
        [HttpGet]
        [Route("v1/consultas/fundeados-otimizado")]
        [SwaggerOperation(OperationId = "8F307FA9-91D8-4149-B5AA-3964123978DC")]
        public async Task<IActionResult> ObterFundeadosOtimizado()
        {
            try
            {
                var retorno = await _consultasServico.ObterFundeadosOtimizado();
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
        /// Obtém dados para a lineup de operacao.
        /// </summary>
        /// <returns>Lista de viaens para o lineup.</returns>
        [HttpGet]
        [Route("v1/consultas/operacao")]
        [SwaggerOperation(OperationId = "11BB179C-2BA7-4194-A5D7-491245711571")]
        public async Task<IActionResult> ObterOperacao()
        {
            try
            {
                var retorno = await _consultasServico.ObterOperacao();
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
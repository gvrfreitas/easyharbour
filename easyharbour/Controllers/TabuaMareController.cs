using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyharbour.Common;
using easyharbour.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace easyharbour.Api.Controllers
{
   
    [ApiController]
    public class TabuaMareController : BaseController
    {

        private readonly TabuaMareServico _tabuaMareServico;

        public TabuaMareController(TabuaMareServico tabuaMareServico)
        {
            _tabuaMareServico = tabuaMareServico;
        }



        /// <summary>
        /// Realiza a improtação das atracações programadas.
        /// </summary>
        /// <param name="file0">Arquivo CSV.</param>
        /// <returns>Mensagem de sucesso ou fracasso da operação.</returns>
        [HttpGet]
        [Route("v1/mares/tabua-mare")]
        [SwaggerOperation(OperationId = "034F0C35-E698-4246-8A35-A32EC5F86A8A")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var retorno = await _tabuaMareServico.Obter();
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
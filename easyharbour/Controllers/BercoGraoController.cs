using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyharbour.Common;
using easyharbour.DTO;
using easyharbour.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace easyharbour.Api.Controllers
{

    [ApiController]
    public class BercoGraoController : ControllerBase
    {

        private readonly BercoGraoServico _bercoGraoServico;

        public BercoGraoController(BercoGraoServico bercoGraoServico)
        {
            _bercoGraoServico = bercoGraoServico;
        }

        /// <summary>
        /// Obtém todos os berços cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/berco-graos/obter")]
        [SwaggerOperation(OperationId = "C63336BB-915E-45AF-B68C-A80DEE5F4209")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var retorno = await _bercoGraoServico.Obter();
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
        /// Obtém todos os berços cadastrados
        /// <paramref name="id"> Identificador do registro no sistema</paramref>
        /// </summary>
        /// <returns>registro cadastrado no sistema.</returns>
        [HttpGet]
        [Route("v1/berco-graos/obter-por-id")]
        [SwaggerOperation(OperationId = "37267319-BF77-4EB9-90AE-270FB5FB1C66")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var retorno = await _bercoGraoServico.ObterPorId(id);
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
        /// Obtém todos os berços cadastrados
        /// <paramref name="id"> Identificador do registro no sistema</paramref>
        /// </summary>
        /// <returns>registro cadastrado no sistema.</returns>
        [HttpPost]
        [Route("v1/berco-graos/cadastrar")]
        [SwaggerOperation(OperationId = "E8159F26-CC90-423A-8E5B-78F4AC8BD938")]
        public async Task<IActionResult>Cadastrar(BercoGraoDto dto)
        {
            try
            {
                var retorno = await _bercoGraoServico.Cadastrar(dto);
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
        /// Obtém todos os berços cadastrados
        /// <paramref name="id"> Identificador do registro no sistema</paramref>
        /// </summary>
        /// <returns>registro cadastrado no sistema.</returns>
        [HttpPost]
        [Route("v1/berco-graos/editar")]
        [SwaggerOperation(OperationId = "BB093906-6CB2-4CC9-BFCA-71A58B50C400")]
        public async Task<IActionResult> Editar(BercoGraoDto dto)
        {
            try
            {
                var retorno = await _bercoGraoServico.Editar(dto);
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

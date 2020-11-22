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
        /// <returns>Lista de registros cadastrados no sistema.</returns>
        [HttpGet]
        [Route("v1/berco-graos/obter")]
        [SwaggerOperation(OperationId = "DE1428B7-78DB-4004-A797-AC21B84B375E")]
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
        /// Obtém um berço especifico cadastrado no sistema
        /// <paramref name="id"> Identificador do registro no sistema</paramref>
        /// </summary>
        /// <returns>Registro cadastrado no sistema.</returns>
        [HttpGet]
        [Route("v1/berco-graos/obter-por-id")]
        [SwaggerOperation(OperationId = "0213EA37-B13F-4162-ADA8-C012A3912FA4")]
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
        /// Realiza o cadastro de um berço novo
        /// <paramref name="dto"> Json com atributos do registro </paramref>
        /// </summary>
        /// <returns>Booleano identificando se o item foi cadastrado com sucesso.</returns>
        [HttpPost]
        [Route("v1/berco-graos/cadastrar")]
        [SwaggerOperation(OperationId = "ABA89DC5-AEF9-42FE-B280-05F2A867B4EE")]
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
        /// Altera o cadastro de um berço específico
        /// <paramref name="dto"> Json com atributos do registro </paramref>
        /// </summary>
        /// <returns>Booleano identificando se o item foi editado com sucesso.</returns>
        [HttpPost]
        [Route("v1/berco-graos/editar")]
        [SwaggerOperation(OperationId = "20EA1E60-B46F-4771-8446-712D639A8C7F")]
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


        /// <summary>
        /// Remove um berço cadastrado
        /// <paramref name="id"> Identificador do registro no sistema</paramref>
        /// </summary>
        /// <returns>Booleano identificando se o item foi excluido com sucesso.</returns>
        [HttpDelete]
        [Route("v1/berco-graos/excluir")]
        [SwaggerOperation(OperationId = "A00A37B3-36C4-4E39-9B06-10C7CB46D300")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var retorno = await _bercoGraoServico.Excluir(id);
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

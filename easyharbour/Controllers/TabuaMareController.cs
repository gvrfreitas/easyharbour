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
    public class TabuaMareController : BaseController
    {

        private readonly TabuaMareServico _tabuaMareServico;

        public TabuaMareController(TabuaMareServico tabuaMareServico)
        {
            _tabuaMareServico = tabuaMareServico;
        }



        /// <summary>
        /// Obtém todos os registros de maré cadastrados
        /// </summary>
        /// <returns>Lista de registros cadastrados no sistema.</returns>
        [HttpGet]
        [Route("v1/tabua-mare/obter")]
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


        /// <summary>
        /// Obtém os registros de maré de uma data específica
        /// <paramref name="data"> Data de referência para a busca</paramref>
        /// </summary>
        /// <returns>Lista de registros cadastrados no sistema.</returns>
        [HttpGet]
        [Route("v1/tabua-mare/obter-por-data")]
        [SwaggerOperation(OperationId = "4014764B-B156-44FC-883E-AECB68679E5C")]
        public async Task<IActionResult> ObterPorData(DateTime data)
        {
            try
            {
                var retorno = await _tabuaMareServico.ObterPorData(data);
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
        /// Obtém um registros especifico cadastrado no sistema
        /// <paramref name="id"> Identificador do registro no sistema</paramref>
        /// </summary>
        /// <returns>Registro cadastrado no sistema.</returns>
        [HttpGet]
        [Route("v1/tabua-mare/obter-por-id")]
        [SwaggerOperation(OperationId = "289D4402-2E46-416E-8D66-917EE786DC63")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var retorno = await _tabuaMareServico.ObterPorId(id);
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
        /// Realiza o cadastro de um nível de maré novo
        /// <paramref name="dto"> Json com atributos do registro </paramref>
        /// </summary>
        /// <returns>Booleano identificando se o item foi cadastrado com sucesso.</returns>
        [HttpPost]
        [Route("v1/tabua-mare/cadastrar")]
        [SwaggerOperation(OperationId = "D479C2BA-6F9A-4236-A05F-1E5BBBA81A66")]
        public async Task<IActionResult> Cadastrar(TabuaMareDto dto)
        {
            try
            {
                var retorno = await _tabuaMareServico.Cadastrar(dto);
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
        /// Altera o cadastro de um nível de maré específico
        /// <paramref name="dto"> Json com atributos do registro </paramref>
        /// </summary>
        /// <returns>Booleano identificando se o item foi editado com sucesso.</returns>
        [HttpPost]
        [Route("v1/tabua-mare/editar")]
        [SwaggerOperation(OperationId = "BB093906-6CB2-4CC9-BFCA-71A58B50C400")]
        public async Task<IActionResult> Editar(TabuaMareDto dto)
        {
            try
            {
                var retorno = await _tabuaMareServico.Editar(dto);
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
        [Route("v1/tabua-mare/excluir")]
        [SwaggerOperation(OperationId = "0712FBFB-EA9E-4D34-9CFD-6ABCF06CE3FD")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var retorno = await _tabuaMareServico.Excluir(id);
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
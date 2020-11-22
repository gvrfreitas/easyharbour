using easyharbour.Common;
using easyharbour.Dados.Repositorios;
using easyharbour.DTO;
using easyharbour.Repositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class NavioServico
    { 

        public NavioRepositorio _navioRepositorio;

        public NavioServico(NavioRepositorio navioRepositorio)
        {
            _navioRepositorio = navioRepositorio;
        }


        public async Task<List<NavioDTO>> Obter()
        {
            return await _navioRepositorio.Obter();
        }

        public async Task<NavioDTO> ObterPorId( Guid id)
        {
            return await _navioRepositorio.ObterPorId(id);
        }

        public async Task<bool> Cadastrar(NavioDTO dto)
        {
            return await _navioRepositorio.Cadastrar(dto);
        }

        public async Task<bool> Editar(NavioDTO dto)
        {
            var itemCadastrado = await _navioRepositorio.ObterPorId(dto.Id);
            if(itemCadastrado == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            return await _navioRepositorio.Editar(dto);
        }

        public async Task<bool> Excluir(Guid id)
        {
            return await _navioRepositorio.Excluir(id);
        }

    }
}

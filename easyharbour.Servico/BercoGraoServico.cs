using easyharbour.Common;
using easyharbour.DTO;
using easyharbour.Repositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class BercoGraoServico
    { 

        public BercoGraoRepositorio _bercoGraoRepositorio;

        public BercoGraoServico(BercoGraoRepositorio bercoGraoRepositorio)
        {
            _bercoGraoRepositorio = bercoGraoRepositorio;
        }


   
        public async Task<List<BercoGraoDto>> Obter()
        {
            return await _bercoGraoRepositorio.Obter();
        }

        public async Task<BercoGraoDto> ObterPorId( Guid id)
        {
            return await _bercoGraoRepositorio.ObterPorId(id);
        }

        public async Task<bool> Cadastrar(BercoGraoDto dto)
        {
            return await _bercoGraoRepositorio.Cadastrar(dto);
        }

        public async Task<bool> Editar(BercoGraoDto dto)
        {
            var itemCadastrado = await _bercoGraoRepositorio.ObterPorId(dto.Id);
            if(itemCadastrado == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            return await _bercoGraoRepositorio.Editar(dto);
        }



    }
}

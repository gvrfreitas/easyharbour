using easyharbour.Dados.Repositorios;
using easyharbour.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class TabuaMareServico
    {
        public TabuaMareRepositorio _tabuaMareRepositorio;

        public TabuaMareServico(TabuaMareRepositorio tabuaMareRepositorio)
        {
            _tabuaMareRepositorio = tabuaMareRepositorio;
        }


        public async Task<List<TabuaMareDto>> Obter()
        {
            return await _tabuaMareRepositorio.Obter();
        }


        public async Task<List<TabuaMareDto>> ObterPorData(DateTime data)
        {
            return await _tabuaMareRepositorio.ObterPorData(data);
        }


        public async Task<TabuaMareDto> ObterPorId(Guid id)
        {
            return await _tabuaMareRepositorio.ObterPorId(id);
        }

        public async Task<bool> Cadastrar(TabuaMareDto dto)
        {
            return await _tabuaMareRepositorio.Cadastrar(dto);
        }

        public async Task<bool> Editar(TabuaMareDto dto)
        {
            return await _tabuaMareRepositorio.Editar(dto);
        }

        public async Task<bool> Excluir(Guid id)
        {
            return await _tabuaMareRepositorio.Excluir(id);
        }


    }
}

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

    }
}

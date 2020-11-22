using easyharbour.Dados.Repositorios;
using easyharbour.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class ConsultasServico
    {
        public readonly AtracacaoServico _atracacaoServico;
        public readonly NavioServico _naviooServico;
        public readonly BercoGraoServico _bercoGraoServico;
        public readonly ViagemRepositorio _viagemRepositorio;

        public ConsultasServico(AtracacaoServico atracacaoServico,
                                NavioServico naviooServico,
                                BercoGraoServico bercoGraoServico,
                                ViagemRepositorio viagemRepositorio)
        {
            _atracacaoServico = atracacaoServico;
            _naviooServico = naviooServico;
            _bercoGraoServico = bercoGraoServico;
            _viagemRepositorio = viagemRepositorio;
    }


        public async Task<List<LineUpDto>> ObterFundeados()
        {
            var listaAtracados = await  _atracacaoServico.ObterNaviosFundiados();
            var lstRetorno = new List<LineUpDto>();

            if (!listaAtracados.Any())
                return null;

            var codigoviagens = listaAtracados.Select(o => o.Viagem).ToList();
            var viagens = await _viagemRepositorio.ObterViagens(codigoviagens);


            foreach (var item in viagens)
            { 
            
            }

            return lstRetorno;

        }




    }
}

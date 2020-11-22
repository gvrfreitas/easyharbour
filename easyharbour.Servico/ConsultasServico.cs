using easyharbour.Common;
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
        public readonly NavioServico _navioServico;
        public readonly BercoGraoServico _bercoGraoServico;
        public readonly ViagemRepositorio _viagemRepositorio;

        public ConsultasServico(AtracacaoServico atracacaoServico,
                                NavioServico navioServico,
                                BercoGraoServico bercoGraoServico,
                                ViagemRepositorio viagemRepositorio)
        {
            _atracacaoServico = atracacaoServico;
            _navioServico = navioServico;
            _bercoGraoServico = bercoGraoServico;
            _viagemRepositorio = viagemRepositorio;
    }


        public async Task<List<LineUpDto>> ObterFundeados()
        {
            var listaAtracados = await _atracacaoServico.ObterNaviosFundiados();
            var lstRetorno = new List<LineUpDto>();

            if (!listaAtracados.Any())
                return null;

            var codigoviagens = listaAtracados.Select(o => o.Viagem).ToList();
            var viagens = await _viagemRepositorio.ObterViagens(codigoviagens);

            foreach (var item in viagens)
            {
                var atracacao = listaAtracados.FirstOrDefault(m => m.Viagem == item.Codigo);

                var lineUp = new LineUpDto()
                {
                    Datachegada = atracacao.AvisoChegada,
                    Berco = item.BercoGrao.Nome,
                    Navio = item.Navio.Descritivo,
                    Calado = item.Navio.Draft,
                    Capacidade = item.Quantidade,
                    Largura = item.Navio.Largura,
                    Produto = item.TipoProduto.GetDescription(),
                    TempoEspera = DateTime.Now.Subtract(atracacao.AvisoChegada).ToString("HH:mm:ss"),
                    AtracacaoPrevista = atracacao.PrevisaoAtracacao,
                };

                lstRetorno.Add(lineUp);
            }

            var indexPosicao = 0;
            foreach (var item in lstRetorno.OrderBy(o => o.Datachegada))
                item.Posicao = (++indexPosicao);

            return lstRetorno;

        }


        public async Task<List<OperacaoDto>> ObterOperacao()
        {
            var listaAtracados = await _atracacaoServico.ObterNaviosFundiados();
            var listaBercos = await _bercoGraoServico.Obter();
            var lstRetorno = new List<OperacaoDto>();

            if (!listaAtracados.Any())
                return null;

            var codigoviagens = listaAtracados.Where(o => o.EmOperacao).Select(o => o.Viagem).ToList();
            var viagens = await _viagemRepositorio.ObterViagens(codigoviagens);


            foreach (var item in viagens)
            {
                var atracado = listaAtracados.FirstOrDefault(o => o.Viagem == item.Codigo);
                var berco = listaBercos.FirstOrDefault(b => b.Id == item.BercoGraoId);

                var navioEmOperacao = new OperacaoDto()
                {
                    Nome = atracado.Navio,
                    Berco = berco.Nome,
                    Produto = "café",
                    PesoBruto = 50,
                    PortoDestino = item.Destino,
                    AtracacaoEfetiva = atracado.AtracacaoEfetiva,
                    Laytime = (item.Quantidade / berco.Prancha),
                    DesatracacaoEfetiva = atracado.Desatracacao,
                };
            }

            return lstRetorno;

        }

    }
}

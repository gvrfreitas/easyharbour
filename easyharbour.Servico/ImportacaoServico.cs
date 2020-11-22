using easyharbour.Repositorio;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace easyharbour.Servico
{
    public class ImportacaoServico
    {
        private readonly ImportacaoRepositorio _repositorio;
        private readonly DadosAtracaoServico _dadosAtracacaoServico;

        public ImportacaoServico(ImportacaoRepositorio repositorio, DadosAtracaoServico dadosAtracacao)
        {
            _repositorio = repositorio;
            _dadosAtracacaoServico = dadosAtracacao;
        }

        public async Task AssociarFichaComposicao(IFormFile file0)
        {
            var listAtracacoes = await _dadosAtracacaoServico.ObterDados(file0.OpenReadStream());            

            _repositorio.Importar(listAtracacoes);
        }
    }
}

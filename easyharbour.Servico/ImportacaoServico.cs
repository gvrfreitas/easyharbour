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


        public ImportacaoServico(ImportacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task AssociarFichaComposicao(IFormFile file0)
        {
            string linha;
            var fileReader = new StreamReader(file0.OpenReadStream());
            while ((linha = fileReader.ReadLine()) != null)
            {
                var registros = linha.Split(';');
                if(registros.Count() > 2)
                {
                  
                }
                
            }

            _repositorio.Importar();
        }
    }
}

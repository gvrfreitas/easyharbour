using easyharbour.DTO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using VLI.SIOP.Operacao.Dados;

namespace easyharbour.Repositorio
{
    public class ImportacaoRepositorio : BaseRepositorio
    {
        public ImportacaoRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public void Importar(List<AtracacaoDto> listaAtracacoes)
        {
            
        }
    }
}

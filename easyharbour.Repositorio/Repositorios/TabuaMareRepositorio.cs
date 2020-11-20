using easyharbour.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using easyharbour.DTO;
using VLI.SIOP.Operacao.Dados;
using Microsoft.EntityFrameworkCore;

namespace easyharbour.Dados.Repositorios
{
    public class TabuaMareRepositorio : BaseRepositorio
    {
        public TabuaMareRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public async Task<List<TabuaMareDto>> Obter()
        {
            return await Contexto.TabuaMare
                   .Select(o => new TabuaMareDto()
                   {
                       Id = o.Id,
                       Altura = o.Altura,
                       Data = o.Data
                   })
                   .ToListAsync();
        }
    }

   
}

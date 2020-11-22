using easyharbour.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using easyharbour.DTO;
using VLI.SIOP.Operacao.Dados;
using Microsoft.EntityFrameworkCore;
using easyharbour.Common;
using easyharbour.Model;

namespace easyharbour.Dados.Repositorios
{
    public class ViagemRepositorio : BaseRepositorio
    {
        public ViagemRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public async Task<List<ViagemDto>> Obter()
        {
            return await Contexto.Viagens
                   .Select(o => BindTo(o))
                   .ToListAsync();
        }


        public async Task<List<ViagemDto>> ObterViagens(List<string> codigos)
        {
            return await Contexto.Viagens
                .Where(m => codigos.Contains(m.Codigo))
                   .Select(o => BindTo(o))
                   .ToListAsync();
        }


        private ViagemDto BindTo(Viagem model)
        {
            return new ViagemDto()
            {
                Id = model.Id,
                Codigo = model.Codigo,
                NavioId = model.NavioId,
                BercoGraoId = model.BercoGraoId,
                TipoProduto = model.TipoProduto,
                Origem = model.Origem,
                Destino = model.Destino,
                Quantidade = model.Quantidade,
                Status = model.Status
            };
        }

    }
}

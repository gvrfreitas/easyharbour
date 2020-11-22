using easyharbour.Common;
using easyharbour.DTO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using VLI.SIOP.Operacao.Dados;
using System.Linq;
using easyharbour.Model;
using Microsoft.EntityFrameworkCore;

namespace easyharbour.Repositorio
{
    public class ImportacaoRepositorio : BaseRepositorio
    {
        public ImportacaoRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public async Task<bool> Importar(List<AtracacaoDto> listaAtracacoes)
        {
            var listaModel = listaAtracacoes
                .Select(o => BindToNew(o))
                .ToList(); 

            Contexto.Atracacao.AddRange(listaModel);
            await Contexto.SaveChangesAsync();
            return true;
        }

        private Atracacao BindToNew(AtracacaoDto dto)
        {
            return new Atracacao()
            {
                Id = dto.Id,
                AtracacaoEfetiva = dto.AtracacaoEfetiva,
                Autorizacao = dto.Autorizacao,
                AvisoChegada = dto.AvisoChegada,
                Desatracacao = dto.Desatracacao,
                EmOperacao = dto.EmOperacao,
                Fundiado = dto.Fundiado,
                Navio = dto.Navio,
                Operador = dto.Operador,
                PrevisaoAtracacao = dto.PrevisaoAtracacao,
                Viagem = dto.Viagem
            };
        }
    }
}

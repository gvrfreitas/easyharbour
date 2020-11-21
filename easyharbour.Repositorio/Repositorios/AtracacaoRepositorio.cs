using easyharbour.DTO;
using easyharbour.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLI.SIOP.Operacao.Dados;

namespace easyharbour.Dados.Repositorios
{
    public class AtracacaoRepositorio : BaseRepositorio
    {
        public AtracacaoRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }
        public async Task<List<AtracacaoDto>> Obter()
        {
            List<AtracacaoDto> Atracacao = await Contexto.Atracacao
                   .Select(o => new AtracacaoDto()
                   {
                       Id = o.Id,
                       Navio = o.Navio,
                       Operador = o.Operador,
                       Viagem = o.Viagem,
                       AvisoChegada = o.AvisoChegada,
                       Autorizacao = o.Autorizacao,
                       PrevisaoAtracacao = o.PrevisaoAtracacao,
                       AtracacaoEfetiva = o.AtracacaoEfetiva,
                       Desatracacao = o.Desatracacao,
                   })
                   .ToListAsync();

            return Atracacao;
        }

        public async Task<List<AtracacaoDto>> ObterNaviosFundiados()
        {
            List<AtracacaoDto> fundiado = await Contexto.Atracacao
                   .Where(o => o.Fundiado == true)
                   .Select(o => new AtracacaoDto()
                   {
                       Id = o.Id
                   }).ToListAsync();

            int countFundiado = fundiado.Count();

            return new List<AtracacaoDto>(countFundiado);
        }

        public async Task<List<AtracacaoDto>> ObterNaviosEmOperacao()
        {
            List<AtracacaoDto> emOperacao = await Contexto.Atracacao
                   .Where(o => o.EmOperacao == true)
                   .Select(o => new AtracacaoDto()
                   {
                       Id = o.Id
                   })
                   .ToListAsync();
            int countEmOperacao = emOperacao.Count();

            return new List<AtracacaoDto>(countEmOperacao);
        }
    }
}

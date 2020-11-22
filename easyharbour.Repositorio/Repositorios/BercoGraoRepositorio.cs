using easyharbour.Common;
using easyharbour.DTO;
using easyharbour.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLI.SIOP.Operacao.Dados;

namespace easyharbour.Repositorio
{
    public class BercoGraoRepositorio : BaseRepositorio
    {
        public BercoGraoRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public async Task<List<BercoGraoDto>> Obter()
        {
            return await Contexto.BercosGraos
                     .Select(o => BindTo(o))
                     .ToListAsync();
        }

        public async Task<bool> Cadastrar(BercoGraoDto dto)
        {
            var model = BindToNew(dto);
            Contexto.BercosGraos.Add(model);
            await Contexto.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Editar(BercoGraoDto dto)
        {
            var model = await Contexto.BercosGraos.FindAsync(dto.Id);

            BindTo(model, dto);
            Contexto.Entry(model).State = EntityState.Modified;
            await Contexto.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Excluir(Guid id)
        {
            var model = await Contexto.BercosGraos.FindAsync(id);

            if (model == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            Contexto.BercosGraos.Remove(model);

            await Contexto.SaveChangesAsync();

            return true;
        }


        private BercoGrao BindToNew(BercoGraoDto dto)
        {
            return new BercoGrao()
            {
                Id = dto.Id,
                CaladoMaximoTrecho = dto.CaladoMaximoTrecho,
                CalaodAlta = dto.CalaodAlta,
                CalaodBaixa = dto.CalaodBaixa,
                Comprimento = dto.Comprimento,
                Nome = dto.Nome,
                DataCadastro = dto.DataCadastro,
                Prancha = dto.Prancha
            };
        }

        private BercoGraoDto BindTo(BercoGrao model)
        {
            return new BercoGraoDto()
            {
                Id = model.Id,
                CaladoMaximoTrecho = model.CaladoMaximoTrecho,
                CalaodAlta = model.CalaodAlta,
                CalaodBaixa = model.CalaodBaixa,
                Comprimento = model.Comprimento,
                Nome = model.Nome,
                DataCadastro = model.DataCadastro,
                Prancha = model.Prancha
            };
        }

        private void BindTo(BercoGrao model, BercoGraoDto dto)
        {
            model.CaladoMaximoTrecho = dto.CaladoMaximoTrecho;
            model.CalaodAlta = dto.CalaodAlta;
            model.CalaodBaixa = dto.CalaodBaixa;
            model.Comprimento = dto.Comprimento;
            model.Nome = dto.Nome;
            model.DataCadastro = dto.DataCadastro;
            model.Prancha = dto.Prancha;
        }

        public async Task<BercoGraoDto> ObterPorId(Guid id)
        {
            var model = await Contexto.BercosGraos.FindAsync(id);

            if (model == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            return BindTo(model);
        }
    }
}

using easyharbour.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using easyharbour.DTO;
using VLI.SIOP.Operacao.Dados;
using Microsoft.EntityFrameworkCore;
using easyharbour.Common;
using easyharbour.Models;

namespace easyharbour.Dados.Repositorios
{
    public class NavioRepositorio : BaseRepositorio
    {
        public NavioRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public async Task<List<NavioDTO>> Obter()
        {
            return await Contexto.Navios
                   .Select(o => BindTo(o))
                   .ToListAsync();
        }

 
        public async Task<bool> Excluir(Guid id)
        {
            var model = await Contexto.TabuaMares.FindAsync(id);

            if (model == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            Contexto.TabuaMares.Remove(model);

            await Contexto.SaveChangesAsync();

            return true;
        }


        public async Task<NavioDTO> ObterPorId(Guid id)
        {
            var model = await Contexto.Navios.FindAsync(id);

            if (model == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            return BindTo(model);
        }

        public async Task<bool> Editar(NavioDTO dto)
        {
            var model = await Contexto.Navios.FindAsync(dto.Id);

            BindTo(model, dto);
            Contexto.Entry(model).State = EntityState.Modified;
            await Contexto.SaveChangesAsync();
            return true;
        }
    

        public async Task<bool> Cadastrar(NavioDTO dto)
        {
            var model = BindToNew(dto);
            Contexto.Navios.Add(model);
            await Contexto.SaveChangesAsync();
            return true;
        }

        private Navio BindToNew(NavioDTO dto)
        {
            return new Navio()
            {
                Id = dto.Id,
                Beam = dto.Beam,
                DataCadastro = dto.DataCadastro,
                Descritivo = dto.Descritivo,
                Draft = dto.Draft
            };
        }

        private NavioDTO BindTo(Navio model)
        {
            return new NavioDTO()
            {
                Id = model.Id,
                Beam = model.Beam,
                DataCadastro = model.DataCadastro,
                Descritivo = model.Descritivo,
                Draft = model.Draft
            };
        }

        private void BindTo(Navio model, NavioDTO dto)
        {
            model.Id = dto.Id;
            model.Beam = dto.Beam;
            model.DataCadastro = dto.DataCadastro;
            model.Descritivo = dto.Descritivo;
            model.Draft = dto.Draft;
        }
    }

}

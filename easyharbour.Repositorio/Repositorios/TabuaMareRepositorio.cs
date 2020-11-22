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
    public class TabuaMareRepositorio : BaseRepositorio
    {
        public TabuaMareRepositorio(AplicacaoContexto contexto) : base(contexto)
        {
        }

        public async Task<List<TabuaMareDto>> Obter()
        {
            return await Contexto.TabuaMares
                   .Select(o => BindTo(o))
                   .ToListAsync();
        }

        public async Task<TabuaMareDto> ObterPorId(Guid id)
        {
            var model = await Contexto.TabuaMares.FindAsync(id);

            if (model == null)
                throw new RegraDeNegocioException(MensagensSistema.NaoEncontrado);

            return BindTo(model);
        }

        public async Task<bool> Editar(TabuaMareDto dto)
        {
            var model = await Contexto.TabuaMares.FindAsync(dto.Id);

            BindTo(model, dto);
            Contexto.Entry(model).State = EntityState.Modified;
            await Contexto.SaveChangesAsync();
            return true;
        }
    

        public async Task<bool> Cadastrar(TabuaMareDto dto)
        {
            var model = BindToNew(dto);
            Contexto.TabuaMares.Add(model);
            await Contexto.SaveChangesAsync();
            return true;
        }

        private TabuaMare BindToNew(TabuaMareDto dto)
        {
            return new TabuaMare()
            {
                Id = dto.Id,
                Altura = dto.Altura,
                Data = dto.Data
            };
        }

        private TabuaMareDto BindTo(TabuaMare model)
        {
            return new TabuaMareDto()
            {
                Id = model.Id,
                Altura = model.Altura,
                Data = model.Data
            };
        }

        private void BindTo(TabuaMare model, TabuaMareDto dto)
        {
                model.Id = dto.Id;
                model.Altura = dto.Altura;
                model.Data = dto.Data;
        }
    }

}

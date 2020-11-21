using easyharbour.Dados.Repositorios;
using easyharbour.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class AtracacaoServico
    {
        public AtracacaoRepositorio _atracacaoRepositorio;

        public AtracacaoServico(AtracacaoRepositorio atracacaoRepositorio)
        {
            _atracacaoRepositorio = atracacaoRepositorio;
        }

        public async Task<List<AtracacaoDto>> Obter()
        {
            return await _atracacaoRepositorio.Obter();
        }

        public async Task<List<AtracacaoDto>> ObterNaviosFundiados()
        {
            return await _atracacaoRepositorio.ObterNaviosFundiados();
        }

        public async Task<List<AtracacaoDto>> ObterNaviosEmOperacao()
        {
            return await _atracacaoRepositorio.ObterNaviosEmOperacao();
        }
    }
}

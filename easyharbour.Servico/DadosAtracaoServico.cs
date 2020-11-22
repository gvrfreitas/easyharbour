using easyharbour.Common;
using easyharbour.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class DadosAtracaoServico
    {

        private void PopularBanco(List<AtracacaoDto> atracacao, ref ExcelWorksheet ws)
        {
            var index = 2;

            foreach (var dado in atracacao)
            {
                dado.Id = Guid.Parse(ws.Cells["A" + index].Value.ToString());
                dado.Navio = ws.Cells["C" + index].Value.ToString();
                dado.Viagem = Int32.Parse(ws.Cells["E" + index].Value.ToString());
                dado.Operador = ws.Cells["F" + index].Value.ToString();
                dado.AvisoChegada = DateTime.Parse(ws.Cells["G" + index].Value.ToString());
                dado.Autorizacao = DateTime.Parse(ws.Cells["H" + index].Value.ToString());
                dado.PrevisaoAtracacao = DateTime.Parse(ws.Cells["I" + index].Value.ToString());
                dado.AtracacaoEfetiva = DateTime.Parse(ws.Cells["J" + index].Value.ToString());
                dado.Desatracacao = DateTime.Parse(ws.Cells["K" + index].Value.ToString());
            }
        }

        public async Task<List<AtracacaoDto>> ObterDados(Stream arquivo)
        {
            try
            {
                var listaAtracacoes = new List<AtracacaoDto>();
                using (var pck = new ExcelPackage(arquivo))
                {
                    var ws = pck.Workbook.Worksheets[0];
                    PopularBanco(listaAtracacoes, ref ws);
                }
                return listaAtracacoes;
            }
            catch (Exception)
            {
                throw new RegraDeNegocioException(MensagensSistema.ErroLeituraExcel);
            }
        }
    }
}

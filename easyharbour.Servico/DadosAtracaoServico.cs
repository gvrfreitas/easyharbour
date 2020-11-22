using easyharbour.Common;
using easyharbour.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class DadosAtracaoServico
    {

        private void PopularBanco(List<AtracacaoDto> atracacao, ref ExcelWorksheet ws)
        {
            var lastRow = ws.Cells.Where(cell => !string.IsNullOrEmpty(cell.Value?.ToString() ?? string.Empty)).LastOrDefault().End.Row;

            for (int index = 3; index <= lastRow; index++)
            {
                if (!string.IsNullOrEmpty(ws.Cells["A" + index].Value.ToString()))
                {
                    var dado = new AtracacaoDto()
                    {
                        Id = Guid.NewGuid(),
                        Navio = ws.Cells["C" + index].Value.ToString(),
                        Viagem = ws.Cells["D" + index].Value.ToString(),
                        Operador = ws.Cells["F" + index].Value.ToString(),
                        AvisoChegada = DateTime.Parse(ws.Cells["G" + index].Value.ToString()),
                        Autorizacao = ws.Cells["H" + index] != null ? DateTime.MinValue : DateTime.Parse(ws.Cells["H" + index].Value.ToString()),
                        PrevisaoAtracacao = ws.Cells["I" + index] != null ? DateTime.MinValue : DateTime.Parse(ws.Cells["I" + index].Value.ToString()),
                        AtracacaoEfetiva = ws.Cells["J" + index] != null ? DateTime.MinValue : DateTime.Parse(ws.Cells["J" + index].Value.ToString()),
                        Desatracacao = ws.Cells["K" + index] != null ? DateTime.MinValue : DateTime.Parse(ws.Cells["K" + index].Value.ToString()),
                        Fundiado = false,
                        EmOperacao = false
                    };
                    atracacao.Add(dado);
                }
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
            catch (Exception ex)
            {
                throw new RegraDeNegocioException(MensagensSistema.ErroLeituraExcel);
            }
        }
    }
}


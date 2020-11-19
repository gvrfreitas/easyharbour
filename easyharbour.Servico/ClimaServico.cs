using easyharbour.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{
    public class ClimaServico : ConsultaExternaServico
    {
        public ClimaServico(string dnsApi, IConfiguration configuration) : base(dnsApi, configuration)
        {
        }


        public async Task<List<ClimaDataDto>> ObterClimaDozeHoras(string cidade, string chave)
        {
            return await TratarResposta<List<ClimaDataDto>>($"forecasts/v1/hourly/12hour/{cidade}?apikey={chave}&language=pt-br&metric=true", Verbo.GET);
        }

        public async Task<List<ClimaDozeHorasDTo>> ObterClima()
        {
            List<ClimaDozeHorasDTo> lstClima = null;
            var retorno = await ObterClimaDozeHoras(_config["Clima:Cidade"], _config["Clima:ApiKey"]);

            if(retorno.Any())
            {
                lstClima = retorno.Select(o => new ClimaDozeHorasDTo()
                {
                    Data = o.DateTime,
                    Descricao = o.IconPhrase,
                    ChanceChuva = o.PrecipitationProbability,
                    Chovendo = o.HasPrecipitation,
                    Temperatura = o.Temperature.Value
                }).ToList();
            }

            return lstClima;
        }


    }
}

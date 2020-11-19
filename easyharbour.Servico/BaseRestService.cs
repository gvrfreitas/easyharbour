using easyharbour.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace easyharbour.Servico
{

    public enum Verbo
    {
        GET = 1,
        POST = 2,
        DELETE = 3,
        PUT = 4
    }


    public class ConsultaExternaServico
    {
        protected readonly HttpClient httpClient;
        protected readonly IConfiguration _config;


        public ConsultaExternaServico(string dnsApi, IConfiguration configuration)
        {
            _config = configuration;

            httpClient = new HttpClient
            {
                BaseAddress = new Uri(dnsApi)
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        protected void ChecarRetorno(HttpResponseMessage resposta)
        {
            if (!resposta.IsSuccessStatusCode)
            {
                try
                {
                    var oRetorno = JsonConvert.DeserializeObject<ResultadoOperacao>(resposta.Content.ReadAsStringAsync().Result);
                    throw new HttpRequestException(string.Join(", ", oRetorno.Mensagens));
                }
                catch (HttpRequestException he)
                {
                    throw he;
                }
                catch (Exception)
                {
                    throw new HttpRequestException(resposta.Content.ReadAsStringAsync().Result);
                }
            }
        }


        protected async Task<T> TratarResposta<T>(string rota, Verbo verbo, HttpContent model = null)
        {
            HttpResponseMessage resposta;

            switch (verbo)
            {
                case Verbo.GET:
                    resposta = await httpClient.GetAsync(rota);
                    break;

                case Verbo.POST:
                    resposta = await httpClient.PostAsync(rota, model);
                    break;

                case Verbo.PUT:
                    resposta = await httpClient.PutAsync(rota, model);
                    break;

                case Verbo.DELETE:
                    resposta = await httpClient.DeleteAsync(rota);
                    break;

                default:
                    throw new RegraDeNegocioException(MensagensSistema.VerboHttpNaoMapeado);
            }

            ChecarRetorno(resposta);

            var result = await resposta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected HttpContent ObterContent<T>(T obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

    }
}

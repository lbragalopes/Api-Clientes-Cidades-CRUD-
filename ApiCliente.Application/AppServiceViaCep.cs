using ApiCliente.Application.Interface;
using ApiCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCliente.Application
{
    public class AppServiceViaCep : IAppViaCep
    {
        private readonly IHttpClientFactory clientFactory;
        public AppServiceViaCep(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<ViaCep> GetViaCepJson(string cepOriginal)
        {
            cepOriginal = ApagarCep(cepOriginal);
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://viacep.com.br/ws/" + cepOriginal + "/json/");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ViaCep>();
            }
            return null;
        }
        private string ApagarCep(string cepOriginal)
        {
            return cepOriginal.Replace("-", string.Empty);
        }
    }
}

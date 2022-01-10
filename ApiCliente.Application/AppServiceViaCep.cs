using ApiCliente.Application.Interface;
using ApiCliente.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application
{
    public class AppServiceViaCep : IAppViaCep
    {
        private readonly IHttpClientFactory _clientFactory;


        public AppServiceViaCep(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<ViaCep> GetEnderecoAsync(string cep)
        {


            string url = $"https://ws.apicep.com/cep/{cep}.json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient("viacep");
            var response = await client.SendAsync(request);
            string readString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var endereco = JsonConvert.DeserializeObject<ViaCep>(readString);
                return endereco;
            }
            else
            {
                throw new Exception("Endereço não encontrado.");
            }

        }

    }
}
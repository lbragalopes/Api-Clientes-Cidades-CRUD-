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
        //Method to get data needed from the Via Cap API
        public async Task<ViaCep> GetViaCepJson(string cepOriginal)
        {
            cepOriginal = CleanCep(cepOriginal);
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://viacep.com.br/ws/" + cepOriginal + "/json/");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)//if cep found send ViaCep with info else send null
            {
                return await response.Content.ReadFromJsonAsync<ViaCep>();
            }
            return null;
        }

        //Method to transform cpf string to one that can be accepted by the Via Cap API
        private string CleanCep(string cepOriginal)
        {
            return cepOriginal.Replace("-", string.Empty);
        }
    }
}
//        private readonly IHttpClientFactory httpClientFactory;
//        private readonly string url;


//        public AppServiceViaCep  (IHttpClientFactory httpClientFactory)
//        {

//            this.httpClientFactory = httpClientFactory;
//           url = "https://viacep.com.br/ws/{0}/json/";
//        }


//        public async Task<ViaCep> GetEnderecoAsync(string cep)
//        {

//            var client = httpClientFactory.CreateClient();

//            var response = await client.GetAsync(string.Format(url, cep));

//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();

//                var endereco = JsonConvert.DeserializeObject<ViaCep>(content);

//                if (string.IsNullOrEmpty(endereco.Cep))
//                    return null;

//                return endereco;
//            }

//            return null;
//        }
//    }
//}

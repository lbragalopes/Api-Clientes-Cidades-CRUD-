using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace ApiCliente.IntegrationTest.Config
{

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestFixture<StartupApiTest>>
    {
    }

    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        private readonly ApiClienteFactory<TStartup> _factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("http://localhost/"),
                HandleCookies = false,
                MaxAutomaticRedirections = 7
            };


            _factory = new ApiClienteFactory<TStartup>();
            Client = _factory.CreateClient(clientOptions);
        }


        internal async Task<T> RecuperarConteudoRequisicao<T>(HttpResponseMessage response)
        {
            var dados = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dados);
        }

        internal async Task TestarRequisicaoComErro(HttpResponseMessage resposta, string mensagemErroEsperada)
        {
            resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var mensagemErroRequest = await resposta.Content.ReadAsStringAsync();

            mensagemErroRequest.Trim().Should().Be(mensagemErroEsperada.Trim());
        }

        internal async Task TestarRequisicaoComErro(HttpResponseMessage resposta, List<string> erros)
        {
            var mensagemErroEsperada = "";

            erros.ForEach(erro =>
            {
                mensagemErroEsperada += $"{erro}{Environment.NewLine}";
            });

            await TestarRequisicaoComErro(resposta, mensagemErroEsperada);
        }

        internal HttpContent GerarCorpoRequisicao<T>(T conteudo)
        {
            return new StringContent(JsonConvert.SerializeObject(conteudo), Encoding.UTF8, "application/json");
        }
        internal async Task TestarRequisicaoInvalida(HttpResponseMessage response, string mensagemErro)
        {
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        // //public async Task AcessarApi()
        //// {

        //     // Recriando o client para evitar configurações de Web
        //   //  Client = _factory.CreateClient();

        //     //var content = PrepararConteudoEnviarApi();
        //    // var response = await Client.PostAsync("api/cliente/");
        //     //response.EnsureSuccessStatusCode();

        //// }



        public void Dispose()
        {
            Client?.Dispose();
            _factory?.Dispose();
        }
    }
}
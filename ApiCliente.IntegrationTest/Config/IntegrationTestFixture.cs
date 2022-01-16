using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ApiCliente.IntegrationTest.Config
{


    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestFixture<StartupApiTest>> { }

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



         public StringContent PrepararConteudoEnviarApi(object dado)
        {
          return new StringContent(
                 JsonSerializer.Serialize(dado),
                 Encoding.UTF8,
                 MediaTypeNames.Application.Json);
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
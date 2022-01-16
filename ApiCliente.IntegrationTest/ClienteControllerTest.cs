using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ApiCliente.IntegrationTest.Config;
using System;
using ApiCliente.Domain.Entity;

namespace ApiCliente.IntegrationTest
{

    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class ClienteControllerTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _integrationTest;

        public ClienteControllerTest(IntegrationTestFixture<StartupApiTest> integrationTest)
        {
            _integrationTest = integrationTest;
                
        }

        [Fact(DisplayName = "Listar itens cliente"), TestPriority(2)]
        [Trait("Cliente", "Integração API")]
        public async Task ListarItem_Cliente_DeveRetornarComSucesso()
        {
            // Act
            var deleteResponse = await _integrationTest.Client.GetAsync($"api/cliente/");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
        }
          

        [Fact(DisplayName = "Adicionar novo cliente"), TestPriority(1)]
        [Trait("Cliente", "Integração API")]
        public async Task AdicionarItem_NovoCliente_DeveRetornarComSucesso()
        {
            // Arrange
            var itemInfo = new Cliente
            {
                Nome = "ClienteTeste",
                //DataNascimento = "2001008",
                Cep = "32113514"
               
            };

            var content = _integrationTest.PrepararConteudoEnviarApi(itemInfo);
            // Act
            var postResponse = await _integrationTest.Client.PostAsync("api/cliente/", content);

            // Assert 
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Remover item cliente"), TestPriority(3)]
        [Trait("Cliente", "Integração API")]
        public async Task RemoverItem_Cliente_DeveRetornarComSucesso()
        {
            // Arrange
            var Id = 1;

            // Act
            var deleteResponse = await _integrationTest.Client.DeleteAsync($"api/cliente/{Id}");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
        }
    }
}

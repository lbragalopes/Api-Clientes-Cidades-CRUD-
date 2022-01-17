using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ApiCliente.IntegrationTest.Config;
using System;
using ApiCliente.Domain.Entity;
using System.Net.Http;
using System.Text;
using System.Net.Mime;
using System.Net;
using ApiCliente.Application.DTO;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

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

        [Fact(DisplayName = "Listar clientes"), TestPriority(3)]
        [Trait("Cliente", "Integração API")]
        public async Task ListarCliente_DeveRetornarComSucesso()
        {

            // Act
            var postResponse = await _integrationTest.Client.GetAsync($"api/cliente/");

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Buscar cliente por Id com sucesso"), TestPriority(6)]
        [Trait("Cliente", "Integração API ")]
        public async Task BuscarCliente_porId_DeveRetornarComSucesso()
        {
            
            // Act
            var postResponse = await _integrationTest.Client.GetAsync($"api/cliente/3");

            // Assert
            postResponse.EnsureSuccessStatusCode();


        }

        [Fact(DisplayName = "Adicionar cliente com Sucesso"), TestPriority(1)]
        [Trait("Cliente", "Integração API")]
        public async Task QuandoAdicionarNovoCliente_DeveRetornar_Sucesso()
        {
            // Arrange
            var itemInfo = new 
            {
                nome = "Cliente Teste",
                dataNascimento = "2010-10-10",
                cep = "30411325"

            };

            var content = _integrationTest.GerarCorpoRequisicao(itemInfo);
            // Act
            var postResponse = await _integrationTest.Client.PostAsync("api/cliente/", content);

            // Assert 
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Adicionar novo cliente - sem CEP"), TestPriority(2)]
        [Trait("Cliente", "Integração API")]
        public async Task QuandoAdicionarNovoCliente_DeveRetornar_BadRequest()
        {
            // Arrange
            var itemInfo = new 
            {
                Nome = "Cliente Teste",
                Cep = ""

            };

            var content = _integrationTest.GerarCorpoRequisicao(itemInfo);
            // Act
            var postResponse = await _integrationTest.Client.PostAsync("api/cliente/", content);

            // Assert 
            Assert.False(postResponse.IsSuccessStatusCode);
        }

        [Fact(DisplayName = "Atualizar cliente"), TestPriority(4)]
        [Trait("Cliente", "Integração API")]
        public async Task QuandoAtualizarCliente_DeveRetornar_Sucesso()
        {
            // Arrange
            var itemInfo = new 
            {
                nome = "Api Cliente Teste",
                cep = "32113200"

            };
           
           var content = _integrationTest.GerarCorpoRequisicao(itemInfo);
           

            var postResponse = await _integrationTest.Client.PutAsync($"api/cliente/{new Random().Next()}", content);

            // Act
                     
            postResponse = await _integrationTest.Client.PutAsync(postResponse.Headers.Location, content);
       
            // Assert 
            Assert.False(postResponse.IsSuccessStatusCode);
        }



        [Fact(DisplayName = "Remover cliente"), TestPriority(5)]
        [Trait("Cliente", "Integração API")]
        public async Task Remover_Cliente_DeveRetornarComSucesso()
        {
            var resposta = await _integrationTest.Client.DeleteAsync($"api/cliente/");

            resposta.EnsureSuccessStatusCode();

        }

     
    }
}
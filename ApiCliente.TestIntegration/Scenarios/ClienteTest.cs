using ApiCliente.TestIntegration.Fixtures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiCliente.TestIntegration.Scenarios
{
    public class ClienteTest
    {
        private readonly TestContext _testContext;

        public ClienteTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task ValidarRespostaAPI()
        {
            var response = await _testContext.Client.GetAsync("/api/cliente/values");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
     
  
    }

}

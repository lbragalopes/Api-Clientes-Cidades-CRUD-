
using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IAppServiceCliente _clienteAppService;
        public ClienteController(IAppServiceCliente clienteAppService)
        {
            _clienteAppService = clienteAppService;

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var results = _clienteAppService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível exibir a lista de clientes. {ex.Message}");
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound("Não existe cliente com Id = 0");

                var result = _clienteAppService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não existe cliente cadastrado no ID informado. {ex.Message}");
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ClienteDto clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                _clienteAppService.Add(clienteDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível cadastrar o cliente. {ex.Message}");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ClienteDto clienteDTO)
        {
            try

            {
                if (id == 0)
                    return NotFound("Não existe cliente com Id = 0");

                _clienteAppService.Update(id, clienteDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível atualizar o cliente com o Id informado.");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound("Não existe cliente com Id = 0");

                var cliente = _clienteAppService.GetById(id);
                if (cliente != null)
                {

                    _clienteAppService.Remove(id);
                    return Ok("Cliente Removido com sucesso!");
                }
                else
                {
                    return NotFound("Nenhum cadastro no ID informado.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel excluir o cliente. {ex.Message}");
            }
        }


    }
}

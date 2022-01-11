
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

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

        }


        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                var result = _clienteAppService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }


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

                return this.StatusCode(StatusCodes.Status500InternalServerError, $" {ex.Message}");
            }


        }


        [HttpPut("{id}")]
        public ActionResult Put(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                var cliente = _clienteAppService.GetById(id);
                if (cliente != null)
                {

                    _clienteAppService.Update(id);
                    return Ok("Cliente Atualizado com sucesso!");
                }
                else
                {
                    return NotFound();

                }
            }

            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $" {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                var cliente = _clienteAppService.GetById(id);
                if (cliente != null)
                {
                    _clienteAppService.Remove(id);
                    return Ok("Cliente Removido com sucesso!");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    
    }
}
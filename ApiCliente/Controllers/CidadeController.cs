using ApiCliente.Application.DTO;
using ApiCliente.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly IAppServiceCidade _cidadeAppService;

        public CidadeController(IAppServiceCidade cidadeAppService)
        {
            _cidadeAppService = cidadeAppService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var results = _cidadeAppService.GetAll();
                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível exibir a lista de Cidades.");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                var result = _cidadeAppService.GetById(id);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não existe cidade cadastrada no ID informado.");
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] CidadeDto cidadeDTO)
        {
            try
            {
                if (cidadeDTO == null)
                    return NotFound();

                _cidadeAppService.Add(cidadeDTO);
                return Ok("Cidade cadastrada com sucesso!");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao cadastrar a cidade.");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, CidadeDto cidadeDTO)

        {
            try
            {
                if (id == 0)
                    return NotFound();

                _cidadeAppService.Update(id, cidadeDTO);
                return Ok("Cidade atualizada com sucesso!");

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível atualizar a cidade.");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();


                _cidadeAppService.Remove(id);
                return Ok("Cidade removida com sucesso!");

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel excluir a cidade.");
            }
        }
    }
}
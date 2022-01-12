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

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var results = _cidadeAppService.GetAll();

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

                var result = _cidadeAppService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha: {ex.Message}");
            }
        }

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
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha: {ex.Message}");
            }
        }
        
        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] CidadeDto cidadeDTO)
        {
            try
            {
                if (cidadeDTO == null)
                    return NotFound();

                _cidadeAppService.Update(cidadeDTO);
                return Ok("Cidade atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
                                {
            try
            {
                if (id == 0)
                    return NotFound();

                var cidade = _cidadeAppService.GetById(id);
                if (cidade != null)
                {
                    _cidadeAppService.Remove(id);
                    return Ok("Cidade removida com sucesso!");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Faturas.Models;
using Faturas.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faturas.Controllers
{
    [Produces("application/json")]
    [Route("api/funcionarios")]
    public class funcionariosController : ControllerBase
    {
        private readonly IFaturasRepositorio _repo;
        public funcionariosController(IFaturasRepositorio repo)
        {
            _repo = repo;

        }
        // GET: api/funcionarios
        [HttpGet]
        public IActionResult GetAll()
        {
            var funcionariosrepo = _repo.ListarFuncionarios();
            var funcionarios = Mapper.Map<IEnumerable<FuncionarioDTO>>(funcionariosrepo);




            return Ok(funcionarios);
        }

        // GET: api/funcionarios/5
        [HttpGet("{id}", Name = "Getfuncionariobyid")]
        public IActionResult Get(Guid id)
        {
            var funcionariorepo = _repo.ObterBancoPorId(id);
            var funcionario = Mapper.Map<FuncionarioDTO>(funcionariorepo);
            return Ok(funcionario);
        }
        
        // POST: api/funcionarios
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/funcionarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Faturas.Data;
using Faturas.Entidades;
using Faturas.Models;
using Faturas.Repositorio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faturas.Controllers
{
    [Produces("application/json")]
    
    public class ContaBancariaController : ControllerBase
    {
        private readonly IFaturasRepositorio _repo;

        public ContaBancariaController(IFaturasRepositorio repo)
        {
            this._repo = repo;
        }

         [HttpGet("api/banco/{bancoId}/contabancaria")]
        public IActionResult ObterContasBancarias(Guid bancoId)
        {
            var contasbankrepo = _repo.ListarContasNoBanco(bancoId);

            var contasbank = Mapper.Map<IEnumerable<ContaBancariaDTO>>(contasbankrepo);

            return Ok(contasbank);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contasbancariasrepo= _repo.ListarContasBancarias();
            var contasbancarias = Mapper.Map<IEnumerable<ContaBancariaDTO>>(contasbancariasrepo);            
            return Ok(contasbancarias);
        }

        [HttpGet("{id}", Name = "ObterContaBancariaPorId")]
        public IActionResult ObterContaBancariaPorId(Guid id)
        {
            var contabancariarepo = _repo.ObterContaBancariaPorId(id);
            var contabank = Mapper.Map<ContaBancariaDTO>(contabancariarepo);

            return Ok(contabank);
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public IActionResult AdicionarConta([FromBody] ContaBancaria contabank)
        {
            if (contabank == null)
            {
                return BadRequest("Objecto vazio.");
            }

            _repo.AddConta(contabank);
            return CreatedAtRoute(
                  "ObterContaBancariaPorId",
                  new { id = contabank.contaBancariaId },
                  contabank);
        }


        
    }
}
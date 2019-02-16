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
    [Route("api/movimentobancario")]
    public class MovimentoBancarioController : ControllerBase
    {
        private readonly IFaturasRepositorio _repo;

        public MovimentoBancarioController(IFaturasRepositorio repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movimentobankrepo= _repo.ListarMovimentosBancarios();
            var movbank = Mapper.Map<IEnumerable<MovimentoBancarioDTO>>(movimentobankrepo);            
            return Ok(movbank);
        }

        [HttpGet("{id}", Name = "ObterMovBankPorId")]
        public IActionResult ObterMovimentoBank(Guid id)
        {
            var movbankrepo = _repo.ObterMovimentoBancarioPorId(id);
            var movbank = Mapper.Map<BancoDTO>(movbankrepo);

            return Ok(movbank);
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public IActionResult AdicionarCliente([FromBody] MovimentoBancario movbank)
        {
            if (movbank == null)
            {
                return BadRequest("Objecto vazio.");
            }

            _repo.AddMovimentoBancario(movbank);
            return CreatedAtRoute(
                  "ObterMovBankPorId",
                  new { id = movbank.MovimentoBancarioId },
                  movbank);
        }
        
    }
}
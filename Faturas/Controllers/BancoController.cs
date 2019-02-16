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
using Newtonsoft.Json.Linq;

namespace Faturas.Controllers
{
    [Produces("application/json")]
    [Route("api/banco")]
    public class BancoController : ControllerBase
    {
        private readonly IFaturasRepositorio _repo;

        public BancoController(IFaturasRepositorio repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bancosrepo= _repo.ListarBancos();
            var bancos = Mapper.Map<IEnumerable<BancoDTO>>(bancosrepo);            
            return Ok(bancos);
        }

        [HttpGet("{id}", Name = "ObterBancoPorId")]
        public IActionResult ObterBanco(Guid id)
        {
            var bancorepo = _repo.ObterBancoPorId(id);
            var banco = Mapper.Map<BancoDTO>(bancorepo);

            return Ok(banco);
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public IActionResult AdicionarBanco([FromBody] JObject banco)
        {
            Banco p = banco.ToObject<Banco>();
            if (p == null)
            {
                return BadRequest("Objecto vazio.");
            }

            _repo.AddBanco(p);
            var bank = Mapper.Map<BancoDTO>(p);
            return CreatedAtRoute(
                  "ObterBancoPorId",
                  new { id = bank.bancoId },
                  bank);
        }



        
    }
}
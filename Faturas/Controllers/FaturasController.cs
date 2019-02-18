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
    [Route("api/fatura")]
    public class FaturasController : Controller
    {
        private readonly IFaturasRepositorio _repo;
     

        public FaturasController(IFaturasRepositorio repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var faturasrepo = _repo.ListarFaturas();
            var faturas = Mapper.Map<IEnumerable<FaturaDTO>>(faturasrepo);




            return  Ok(faturas);
        }

        [HttpGet("{id}", Name = "ObterFaturaPorId")]
        public IActionResult ObterFatura(Guid id)
        {
            var faturarepo = _repo.ObterFatura(id);
            var fatura = Mapper.Map<FaturaDTO>(faturarepo);

            return Ok(fatura);
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public IActionResult AdicionarCli([FromBody] JObject fatura)
        {
            Fatura p = fatura.ToObject<Fatura>();
            if (fatura == null)
            {
               return BadRequest("Objecto vazio.");

            }

            _repo.AddFatura(p);

            FaturaDTO fat = Mapper.Map<FaturaDTO>(p);
             return CreatedAtRoute(
                   "ObterFaturaPorId",
                   new { id = fat.ClienteId },
                   fat);

           
        }





    }
}
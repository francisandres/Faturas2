using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Faturas.Entidades;
using Faturas.Models;
using Faturas.Repositorio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faturas.Controllers
{
    [Produces("application/json")]
    [Route("api/Pagamentos")]
    public class PagamentosController : Controller
    {
        private IFaturasRepositorio _repo;

        public PagamentosController(IFaturasRepositorio repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pagamentosrepo = _repo.ListarPagamentos();
            var pagamentos = Mapper.Map<IEnumerable<PagamentoDTO>>(pagamentosrepo);




            return Ok(pagamentos);
        }

        [HttpGet("{id}", Name = "ObterPagamentoPorId")]
        public IActionResult ObterCliente(Guid id)
        {
            var pagamentorepo = _repo.ObterPagamento(id);
            var pagamento = Mapper.Map<PagamentoDTO>(pagamentorepo);

            return Ok(pagamento);
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public IActionResult AdicionarCliente([FromBody] Pagamento pagamento)
        {
            if (pagamento == null)
            {
                return BadRequest("Objecto vazio.");
            }

            _repo.AddPagamento(pagamento);
            return CreatedAtRoute(
                  "ObterPagamentoPorId",
                  new { id = pagamento.PagamentoId },
                  pagamento);
        }
    }
}
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
    [Route("api/transacao")]
    public class TransacoesController : Controller
    {

        private readonly IFaturasRepositorio _repo;


        public TransacoesController(IFaturasRepositorio repo)
        {
            _repo = repo;


        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var transacoesrepo = _repo.ListarTransacoes();
            var transacoes = Mapper.Map<IEnumerable<TransacaoDTO>>(transacoesrepo);




            return Ok(transacoes);
        }

        [HttpGet("{id}", Name = "ObterTransacaoporId")]
        public IActionResult ObterTransacoesCliente(Guid id)
        {
            var transacrepo = _repo.ListarTransacaoCliente(id);
            var transacoes = Mapper.Map<IEnumerable<TransacaoDTO>>(transacrepo);

            return Ok(transacoes);
        }
    }
}
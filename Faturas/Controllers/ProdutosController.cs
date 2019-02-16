using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Faturas.Entidades;
using Faturas.Models;
using Faturas.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faturas.Controllers
{
    [Produces("application/json")]
    [Route("api/produto")]
    public class ProdutosController : Controller
    {
        private readonly IFaturasRepositorio _repo;


        public ProdutosController(IFaturasRepositorio repo)
        {
            _repo = repo;


        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var produtosrepo = _repo.ListarProdutos();
            var produtos = Mapper.Map<IEnumerable<ProdutoDTO>>(produtosrepo);




            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "ObterProdutoPorId")]
        public IActionResult ObterProduto(Guid id)
        {
            var produtorepo = _repo.ObterProduto(id);
            var produto = Mapper.Map<ProdutoDTO>(produtorepo);

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Objecto vazio.");
            }

            _repo.AddProduto(produto);
            return CreatedAtRoute(
                  "ObterProdutoPorId",
                  new { id = produto.ProdutoId },
                  produto);
        }


    }
}
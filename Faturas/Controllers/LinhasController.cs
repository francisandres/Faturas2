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
    public class LinhasController : Controller
    {


        private readonly IFaturasRepositorio _repo;


        public LinhasController(IFaturasRepositorio repo)
        {
            _repo = repo;


        }

        [HttpGet("api/faturas/{FaturaId}/linhas")]
        public IActionResult ObterLinhasDaFatura(Guid FaturaId)
        {
            var linhasdefaturarepo = _repo.ListasLinhasFatura(FaturaId);

            var linhas = Mapper.Map<IEnumerable<LinhaDTO>>(linhasdefaturarepo);

            return Ok(linhas);
        }
    }
}
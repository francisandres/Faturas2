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
    [Route("api/Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IFaturasRepositorio _repo;
        

        public ClientesController(IFaturasRepositorio repo)
        {
            _repo = repo;
           

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var clientesrepo= _repo.ListarClientes();
            var clientes = Mapper.Map<IEnumerable<ClienteDTO>>(clientesrepo);



            
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "ObterClientePorId")]
        public IActionResult ObterCliente(Guid id)
        {
            var clienterepo = _repo.ObterCliente(id);
            var cliente = Mapper.Map<ClienteDTO>(clienterepo);

            return Ok(cliente);
        }


        [HttpPost]
        [EnableCors("AllowAll")]
        public IActionResult AdicionarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Objecto vazio.");
            }

            _repo.AddCliente(cliente);
            return CreatedAtRoute(
                  "ObterClientePorId",
                  new { id = cliente.ClienteId },
                  cliente);
        }


    }



}

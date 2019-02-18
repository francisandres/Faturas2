using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faturas.Data;
using Faturas.Entidades;

namespace Faturas.Controllers
{
    [Produces("application/json")]
    [Route("api/ReceitaOrcamentoes")]
    public class ReceitaOrcamentoesController : Controller
    {
        private readonly FaturasContext _context;

        public ReceitaOrcamentoesController(FaturasContext context)
        {
            _context = context;
        }

        // GET: api/ReceitaOrcamentoes
        [HttpGet]
        public IEnumerable<ReceitaOrcamento> GetReceitaOrcamentos()
        {
            return _context.ReceitaOrcamentos;
        }

        // GET: api/ReceitaOrcamentoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitaOrcamento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receitaOrcamento = await _context.ReceitaOrcamentos.SingleOrDefaultAsync(m => m.receitaId == id);

            if (receitaOrcamento == null)
            {
                return NotFound();
            }

            return Ok(receitaOrcamento);
        }

        // PUT: api/ReceitaOrcamentoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceitaOrcamento([FromRoute] Guid id, [FromBody] ReceitaOrcamento receitaOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receitaOrcamento.receitaId)
            {
                return BadRequest();
            }

            _context.Entry(receitaOrcamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaOrcamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReceitaOrcamentoes
        [HttpPost]
        public async Task<IActionResult> PostReceitaOrcamento([FromBody] ReceitaOrcamento receitaOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReceitaOrcamentos.Add(receitaOrcamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceitaOrcamento", new { id = receitaOrcamento.receitaId }, receitaOrcamento);
        }

        // DELETE: api/ReceitaOrcamentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceitaOrcamento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receitaOrcamento = await _context.ReceitaOrcamentos.SingleOrDefaultAsync(m => m.receitaId == id);
            if (receitaOrcamento == null)
            {
                return NotFound();
            }

            _context.ReceitaOrcamentos.Remove(receitaOrcamento);
            await _context.SaveChangesAsync();

            return Ok(receitaOrcamento);
        }

        private bool ReceitaOrcamentoExists(Guid id)
        {
            return _context.ReceitaOrcamentos.Any(e => e.receitaId == id);
        }
    }
}
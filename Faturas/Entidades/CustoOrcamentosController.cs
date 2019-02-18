using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faturas.Data;

namespace Faturas.Entidades
{
    [Produces("application/json")]
    [Route("api/CustoOrcamentos")]
    public class CustoOrcamentosController : Controller
    {
        private readonly FaturasContext _context;

        public CustoOrcamentosController(FaturasContext context)
        {
            _context = context;
        }

        // GET: api/CustoOrcamentos
        [HttpGet]
        public IEnumerable<CustoOrcamento> GetCustoOrcamentos()
        {
            return _context.CustoOrcamentos;
        }

        // GET: api/CustoOrcamentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustoOrcamento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var custoOrcamento = await _context.CustoOrcamentos.SingleOrDefaultAsync(m => m.custoOrcamentoId == id);

            if (custoOrcamento == null)
            {
                return NotFound();
            }

            return Ok(custoOrcamento);
        }

        // PUT: api/CustoOrcamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustoOrcamento([FromRoute] Guid id, [FromBody] CustoOrcamento custoOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != custoOrcamento.custoOrcamentoId)
            {
                return BadRequest();
            }

            _context.Entry(custoOrcamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustoOrcamentoExists(id))
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

        // POST: api/CustoOrcamentos
        [HttpPost]
        public async Task<IActionResult> PostCustoOrcamento([FromBody] CustoOrcamento custoOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustoOrcamentos.Add(custoOrcamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustoOrcamento", new { id = custoOrcamento.custoOrcamentoId }, custoOrcamento);
        }

        // DELETE: api/CustoOrcamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustoOrcamento([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var custoOrcamento = await _context.CustoOrcamentos.SingleOrDefaultAsync(m => m.custoOrcamentoId == id);
            if (custoOrcamento == null)
            {
                return NotFound();
            }

            _context.CustoOrcamentos.Remove(custoOrcamento);
            await _context.SaveChangesAsync();

            return Ok(custoOrcamento);
        }

        private bool CustoOrcamentoExists(Guid id)
        {
            return _context.CustoOrcamentos.Any(e => e.custoOrcamentoId == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;
namespace EFGetStarted.AspNetCore.NewDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcabamentoController : ControllerBase
    {
        private readonly ArqsiContext _context;

        public AcabamentoController(ArqsiContext context)
        {
            _context = context;
        }

        // GET: api/Acabamento
        [HttpGet]
        public IEnumerable<Acabamento> GetAcabamento()
        {
            return _context.Acabamento;
        }

        // GET: api/Acabamento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcabamento([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acabamento = await _context.Acabamento.FindAsync(id);

            if (acabamento == null)
            {
                return NotFound();
            }

            return Ok(acabamento);
        }

        // PUT: api/Acabamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcabamento([FromRoute] string id, [FromBody] Acabamento acabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acabamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(acabamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcabamentoExists(id))
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

        // POST: api/Acabamento
        [HttpPost]
        public async Task<IActionResult> PostAcabamento([FromBody] Acabamento acabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Acabamento.Add(acabamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcabamento", new { id = acabamento.Id }, acabamento);
        }

        // DELETE: api/Acabamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcabamento([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acabamento = await _context.Acabamento.FindAsync(id);
            if (acabamento == null)
            {
                return NotFound();
            }

            _context.Acabamento.Remove(acabamento);
            await _context.SaveChangesAsync();

            return Ok(acabamento);
        }

        private bool AcabamentoExists(string id)
        {
            return _context.Acabamento.Any(e => e.Id == id);
        }
    }
}
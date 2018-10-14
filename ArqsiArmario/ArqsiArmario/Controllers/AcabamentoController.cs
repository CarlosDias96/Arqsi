using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArqsiArmario.Models;
using ArqsiArmario.DTOs;
using ArqsiArmario.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcabamentoController : ControllerBase
    {
      
        private IAcabamentoRepository repacabamento;

        public AcabamentoController(IAcabamentoRepository acabamentoRepository)
        {
            this.repacabamento = acabamentoRepository;
        }

        [HttpGet]
        public IEnumerable<AcabamentoDto> GetAcabamentos()
        {
            IEnumerable<AcabamentoDto> ListaAcabamentosDTO = Enumerable.Empty<AcabamentoDto>();
            AcabamentoDto aux = new AcabamentoDto();
            foreach(Acabamento acabamento in repacabamento.GetAcabamentos())
            {
                aux = new AcabamentoDto();
                aux.Nome = acabamento.Nome;
                ListaAcabamentosDTO = ListaAcabamentosDTO.Concat(new[] { aux });
            }
            return ListaAcabamentosDTO;
        }

        // GET: api/Acabamentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcabamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acabamento = repacabamento.GetAcabamentoByID(id);

            if (acabamento == null)
            {
                return NotFound();
            }

            AcabamentoDto acabamentoDTO = new AcabamentoDto();
            acabamentoDTO.Nome = acabamento.Nome;

            return Ok(acabamentoDTO);
        }

        // PUT: api/Acabamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcabamento([FromRoute] int id, [FromBody] Acabamento acabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acabamento.Id)
            {
                return BadRequest();
            }

            repacabamento.UpdateAcabamento(acabamento);

            try
            {
                repacabamento.Save();
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

        // POST: api/Acabamentos
        [HttpPost]
        public async Task<IActionResult> PostAcabamento([FromBody] Acabamento acabamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repacabamento.InsertAcabamento(acabamento);
            repacabamento.Save();

            return CreatedAtAction("GetAcabamento", new { id = acabamento.Id }, acabamento);
        }

        // DELETE: api/Acabamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcabamento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acabamento = repacabamento.GetAcabamentoByID(id);
            if (acabamento == null)
            {
                return NotFound();
            }

            repacabamento.DeleteAcabamento(id);
            repacabamento.Save();

            return Ok(acabamento);
        }

        private bool AcabamentoExists(int id)
        {
            return repacabamento.GetAcabamentos().Any(e => e.Id == id);
        }
    }
}
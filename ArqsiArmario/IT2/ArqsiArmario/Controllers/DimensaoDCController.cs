using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.DTOs;
using ArqsiArmario.Models;
using ArqsiArmario.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArqsiArmario.Controllers
{
    [Route("api/[controller]")]
    public class DimensaoDCController : ControllerBase
    {
        private IDimensaoDCRepository repdimensao;


        public DimensaoDCController(IDimensaoDCRepository dimensaoRepository)
        {
            this.repdimensao = dimensaoRepository;
        }

        [HttpGet]
        public IEnumerable<DimensaoDCDto> GetDimensoes()
        {
            IEnumerable<DimensaoDCDto> ListaDimensaoDto = Enumerable.Empty<DimensaoDCDto>();
            DimensaoDCDto aux = new DimensaoDCDto();
            foreach (DimensaoDC dimensao in repdimensao.GetDimensao())
            {
                aux = new DimensaoDCDto();
                aux.AlturaMin = dimensao.AlturaMin;
                aux.AlturaMax = dimensao.AlturaMax;
                ListaDimensaoDto = ListaDimensaoDto.Concat(new[] { aux });
            }
            return ListaDimensaoDto;
        }

        // GET: api/Dimensao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDimensao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dimensao = repdimensao.GetDimensoesByID(id);

            if (dimensao == null)
            {
                return NotFound();
            }

            DimensaoDCDto dimensaoDto = new DimensaoDCDto();

            dimensaoDto.AlturaMin = dimensao.AlturaMin;
            dimensaoDto.AlturaMax = dimensao.AlturaMax;
            return Ok(dimensaoDto);
        }

        // PUT: api/Dimensao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDimensao([FromRoute] int id, [FromBody] DimensaoDC dimensao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temp = repdimensao.GetDimensao().Where<DimensaoDC>(a => a.Id == id);

            DimensaoDC aux = temp.First<DimensaoDC>();
            aux.AlturaMin = dimensao.AlturaMin;
            aux.AlturaMax = dimensao.AlturaMax;
                             

            try
            {
                repdimensao.UpdateDimensao(aux);
                repdimensao.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimensaoExists(id))
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

        // POST: api/Dimensao
        [HttpPost]
        public async Task<IActionResult> PostDimensao([FromBody] DimensaoDC dimensao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repdimensao.InsertDimensao(dimensao);
            repdimensao.Save();

            return CreatedAtAction("GetDimensao", new { id = dimensao.Id }, dimensao);
        }

        // DELETE: api/Dimensao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDimensao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dimensao = repdimensao.GetDimensoesByID(id);
            if (dimensao == null)
            {
                return NotFound();
            }

            repdimensao.DeleteDimensao(id);
            repdimensao.Save();

            return Ok(dimensao);
        }

        private bool DimensaoExists(int id)
        {
            return repdimensao.GetDimensao().Any(e => e.Id == id);
        }
    }
}

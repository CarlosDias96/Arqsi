using System;
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
    public class DimensaoController : ControllerBase
    {
        private IDimensaoRepository repdimensao;

        public DimensaoController(IDimensaoRepository dimensaoRepository)
        {
            this.repdimensao = dimensaoRepository;
        }

        [HttpGet]
        public IEnumerable<DimensaoDto> GetDimensoes()
        {
            IEnumerable<DimensaoDto> ListaDimensoesDTO = Enumerable.Empty<DimensaoDto>();
            DimensaoDto aux = new DimensaoDto();
            foreach (Dimensao dimensao in repdimensao.GetDimensao())
            {
                aux = new DimensaoDto();
                aux.Altura.AlturaMin = dimensao.Altura.AlturaMin;
                aux.Altura.AlturaMax = dimensao.Altura.AlturaMax;
                aux.Largura.AlturaMin = dimensao.Largura.AlturaMin;
                aux.Largura.AlturaMax = dimensao.Largura.AlturaMax;
                aux.Profundidade.AlturaMin = dimensao.Profundidade.AlturaMin;
                aux.Profundidade.AlturaMax = dimensao.Profundidade.AlturaMax;
                ListaDimensoesDTO = ListaDimensoesDTO.Concat(new[] { aux });
            }
            return ListaDimensoesDTO;
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

            DimensaoDto dimensaoDto = new DimensaoDto();
            
            dimensao.Altura.AlturaMin = dimensaoDto.Altura.AlturaMin;
            dimensao.Altura.AlturaMax = dimensaoDto.Altura.AlturaMax;
            dimensao.Largura.AlturaMin = dimensaoDto.Largura.AlturaMin;
            dimensao.Largura.AlturaMax = dimensaoDto.Largura.AlturaMax;
            dimensao.Profundidade.AlturaMin = dimensaoDto.Profundidade.AlturaMin;
            dimensao.Profundidade.AlturaMax = dimensaoDto.Profundidade.AlturaMax;
            return Ok(dimensaoDto);
        }

        // PUT: api/Dimensao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDimensao([FromRoute] int id, [FromBody] Dimensao dimensao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dimensao.Id)
            {
                return BadRequest();
            }

            repdimensao.UpdateDimensao(dimensao);

            try
            {
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
        public async Task<IActionResult> PostDimensao([FromBody] Dimensao dimensao)
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